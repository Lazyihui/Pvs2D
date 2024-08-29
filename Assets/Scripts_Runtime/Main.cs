using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    MainContext ctx;
    bool isTearDown = false;

    [SerializeField] Transform CellGroup;
    void Awake() {
        ctx = new MainContext();
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();

        ctx.Inject(canvas, camera, CellGroup);

        // === Load ===
        ModuleAssets.Load(ctx.assetsContext);
        TemplateInfra.Load(ctx.templateContext);

        Binding(ctx.gameContext);

        Loading.Load(ctx.gameContext);

        // LoginBusiness.Enter(ctx.gameContext);

    }

    void Binding(GameContext ctx) {
        var uiEvent = ctx.uiContext.uiEvent;

        if (ctx.gameEntity.gameStatus == GameStatus.GameBusiness) {

            uiEvent.panel_GoodsElement_CardHandle = (id) => {

                ctx.uiContext.goodsRespository.TryGet(id, out Panel_GoodsElement good);
                good.status = GoodStatus.Cooling;
                if (ctx.gameEntity.handPlant != null) {
                    Debug.Log("已经有植物了");
                    return;
                }
                ctx.gameEntity.handPlant = PlantDomain.Spawn(ctx, good.typeID); // 0x54
                                                                                //1. 还要种植 (先种植在计算) 写完在 CellDomain.Plant 里

                //2. 要进入冷却  并且 要扣除阳光
                // 用卡片来记录来记录阳光
                ctx.uiContext.idService.sunCount -= good.needSunCount;

            };

        } else if (ctx.gameEntity.gameStatus == GameStatus.Loading) {

            uiEvent.panel_Login_LoginHandle = () => {

                UIApp.Panel_Login_Close(ctx.uiContext);
                UIApp.Panel_Point_Open(ctx.uiContext);
                ctx.gameEntity.gameStatus = GameStatus.Pointing;

            };

        }


        uiEvent.panel_PointModifyNameHandle = () => {

            UIApp.Panel_ModifyName_Open(ctx.uiContext);


        };

        uiEvent.panel_ModifyName_ConfirmHandle = (inputName) => {

            Debug.Log("inputName:" + inputName);
            UIApp.Panel_Point_SetName(ctx.uiContext, inputName);
        };

        uiEvent.panel_ModifyName_CancelHandle = () => {

            UIApp.Panel_ModifyName_Close(ctx.uiContext);

        };

        uiEvent.panel_PointAdvanceHandle = () => {

            UIApp.Panel_Point_Close(ctx.uiContext);
            ctx.gameEntity.gameStatus = GameStatus.LoginBusiness;
            LoginBusiness.Enter(ctx);

        };

        uiEvent.panel_PointMiniGameHandle = () => {
        };

        uiEvent.panel_PointBrainHandle = () => {
        };

    }


    void Update() {
        float dt = Time.deltaTime;


        if (ctx.gameContext.gameEntity.gameStatus == GameStatus.Loading) {



        } else if (ctx.gameContext.gameEntity.gameStatus == GameStatus.LoginBusiness) {
            LoginBusiness.Tick(ctx.gameContext, dt);
        } else if (ctx.gameContext.gameEntity.gameStatus == GameStatus.GameBusiness) {
            GameBusiness.Tick(ctx.gameContext, dt);
        } else if (ctx.gameContext.gameEntity.gameStatus == GameStatus.GameOver) {

        } else if (ctx.gameContext.gameEntity.gameStatus == GameStatus.Pause) {
            Pause_Business.Tick(ctx.gameContext, dt);

        }




    }

    void OnDestory() {
        TearDown();
    }

    void OnApplicationQuit() {
        TearDown();
    }

    void TearDown() {
        if (isTearDown) {
            return;
        }
        isTearDown = true;
        // === Unload===
        ModuleAssets.Unload(ctx.assetsContext);
        TemplateInfra.Unload(ctx.templateContext);
    }
}
