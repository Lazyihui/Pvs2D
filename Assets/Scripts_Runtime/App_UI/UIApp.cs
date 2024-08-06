using System;

using UnityEngine;

public static class UIApp {

    // good

    public static void Panel_Goods_Open(UIContext ctx) {

        Panel_Goods panel = ctx.panel_Goods;

        if (panel == null) {
            bool has = ctx.assetsContext.TryGetPanel("Panel_Goods", out GameObject prefab);
            if(!has) {
                Debug.LogError("Panel_Goods not found");
                return;
            }
            panel = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Goods>();
            panel.AddGoodsElement();
            panel.Ctor();
            ctx.panel_Goods = panel;
        }


        panel.Show();



    }
}