using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    MainContext ctx;
    bool isTearDown = false;

    void Awake() {
        ctx = new MainContext();
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();

        ctx.Inject(canvas, camera);

        // === Load ===
        ModuleAssets.Load(ctx.assetsContext);

        Binding();

        UIApp.Panel_Goods_Open(ctx.uiContext);

        GameBusiness.Enter(ctx.gameContext);
    }

    void Binding() {
        var uiEvent = ctx.uiContext.uiEvent;

        uiEvent.panel_GoodsElement_CardHandle = (typeID, plantCount) => {

            Debug.Log("typeID:" + typeID + " plantCount:" + plantCount);
            PlantDomain.Spawn(ctx.gameContext, 1);

            //1. 还要种植 (先种植在计算)

            //2. 要进入冷却  并且 要扣除阳光


        };
    }


    void Update() {
        float dt = Time.deltaTime;

        GameBusiness.Tick(ctx.gameContext, dt);

        UIApp.Panel_GoodsUpdateSunCount(ctx.uiContext);

        int goodlen = ctx.uiContext.goodsRespository.TakeAll(out Panel_GoodsElement[] goods);
        for (int i = 0; i < goodlen; i++) {
            Panel_GoodsElement good = goods[i];
            UIApp.Panel_GoodsElement_SetStatus(ctx.uiContext, good, dt);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            ctx.uiContext.idService.sunCount -= 60;
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
