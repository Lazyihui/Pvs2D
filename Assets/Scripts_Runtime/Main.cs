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

        Binding(ctx.gameContext);



        GameBusiness.Enter(ctx.gameContext);
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

            ctx.gameEntity.handPlant = PlantDomain.Spawn(ctx, PlantConst.SunFlower); // 0x54

            //1. 还要种植 (先种植在计算) 写完在 CellDomain.Plant 里

            //2. 要进入冷却  并且 要扣除阳光
            // 用卡片来记录来记录阳光

            ctx.uiContext.idService.sunCount -= good.needSunCount;

        };
    }


    void Update() {
        float dt = Time.deltaTime;

        GameBusiness.Tick(ctx.gameContext, dt);



        if (Input.GetKeyDown(KeyCode.Space)) {
            
            Debug.Log("mouseWorldPos:" + ctx.moduleInput.mouseWorldPos + "mouseScreenPos:" + ctx.moduleInput.mouseScreenPos);
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
    }
}
