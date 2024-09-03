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

        AudioEntity audio = AudioDomain.Spawn(ctx.gameContext, 0);

        // LoginBusiness.Enter(ctx.gameContext);

    }

    void Binding(GameContext ctx) {
        var uiEvent = ctx.uiContext.uiEvent;


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


        uiEvent.panel_Login_LoginHandle = () => {

            UIApp.Panel_Login_Close(ctx.uiContext);
            UIApp.Panel_Point_Open(ctx.uiContext);
            ctx.gameEntity.gameStatus = GameStatus.Pointing;

        };



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
        // 冒险关卡
        uiEvent.panel_PointAdvanceHandle = () => {

            MapDomain.Spawn(ctx, 0);
            UIApp.Panel_Point_Close(ctx.uiContext);
            ctx.gameEntity.gameStatus = GameStatus.LoginBusiness;
            LoginBusiness.Enter(ctx);

        };
        // 小游戏关卡
        uiEvent.panel_PointMiniGameHandle = () => {

            MapDomain.Spawn(ctx, 1);
            UIApp.Panel_Point_Close(ctx.uiContext);
            ctx.gameEntity.gameStatus = GameStatus.LoginBusiness;
            LoginBusiness.Enter(ctx);
        };
        // 关卡
        uiEvent.panel_PointBrainHandle = () => {
        };
        // 进入游戏的卡片选择

        uiEvent.panel_CardElement_CardHandle = (id) => {
            Debug.Log("id:" + id);
            ctx.uiContext.goodsRespository.TryGet(id, out Panel_GoodsElement card);
            UIApp.Panel_GoodsElementAdd(ctx.uiContext, card.typeID);

            card.status = GoodStatus.Cooling;

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

        // int lenAudio = ctx.gameContext.audioRepository.TakeAll(out AudioEntity[] audios);
        // for (int i = 0; i < lenAudio; i++) {
        //     AudioEntity audio = audios[i];
        //     audio.PlayAudio("Audio/LoseWin");
        // }


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
