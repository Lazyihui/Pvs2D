using System;

using UnityEngine;

public static class UIApp {

    // good

    public static void Panel_Goods_Open(UIContext ctx) {

        Panel_Goods panel = ctx.panel_Goods;

        if (panel == null) {
            bool has = ctx.assetsContext.TryGetPanel("Panel_Goods", out GameObject prefab);
            if (!has) {
                Debug.LogError("Panel_Goods not found");
                return;
            }
            panel = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Goods>();
            panel.Ctor();
            ctx.panel_Goods = panel;
        }


        panel.Show();

    }


    public static void Panel_GoodsElementAdd(UIContext ctx, int typeID) {
        Panel_Goods panel = ctx.panel_Goods;
        panel.AddGoodsElement(ctx, typeID);
    }

    public static void Panel_GoodsUpdateSunCount(UIContext ctx) {
        Panel_Goods panel = ctx.panel_Goods;
        panel.SetSunCount(ctx.idService.sunCount);
    }

    public static void Panel_GoodsElement_SetStatus(UIContext ctx, Panel_GoodsElement goodsElement, float dt) {
        goodsElement.SetStatus(goodsElement.status, ctx.idService.sunCount, dt);
    }


    public static void Panel_Prepare_Open(UIContext ctx) {

        Panel_Prepare panel = ctx.panel_Prepare;

        if (panel == null) {
            bool has = ctx.assetsContext.TryGetPanel("Panel_Prepare", out GameObject prefab);
            if (!has) {
                Debug.LogError("Panel_Prepare not found");
                return;
            }
            panel = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Prepare>();
            panel.Ctor();
            ctx.panel_Prepare = panel;
        }
    }
}