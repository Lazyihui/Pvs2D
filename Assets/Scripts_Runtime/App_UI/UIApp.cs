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

    public static void Panel_CardsElement_SetStatus(UIContext ctx, Panel_GoodsElement cardsElement, float dt) {
        cardsElement.SetStatus(cardsElement.status, ctx.idService.sunCount, dt);
    }

    public static void Panel_Goods_Close(UIContext ctx) {
        Panel_Goods panel = ctx.panel_Goods;
        if (panel == null) {
            return;
        }
        panel.TearDown();
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

        panel.Show();
    }
    public static void Panel_Prepare_Update(UIContext ctx, float dt) {

        Panel_Prepare panel = ctx.panel_Prepare;
        panel.Panel_Update(dt);
    }

    public static bool Panel_Prepare_Close(UIContext ctx) {
        Panel_Prepare panel = ctx.panel_Prepare;
        if (panel == null) {
            return false;
        } else if (panel.isFinish) {
            panel.TearDown();
            return true;
        } else {
            return false;
        }

    }

    public static void Panel_Over_Open(UIContext ctx) {
        Panel_Over panel = ctx.panel_Over;
        if (panel == null) {
            bool has = ctx.assetsContext.TryGetPanel("Panel_Over", out GameObject prefab);
            if (!has) {
                Debug.LogError("Panel_Over not found");
                return;
            }

            panel = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Over>();
            panel.Ctor();
        }

        panel.Show();
    }


    public static void Panel_Over_Close(UIContext ctx) {
        Panel_Over panel = ctx.panel_Over;
        if (panel == null) {
            return;
        }
        panel.TearDown();
    }


    public static void Panel_Login_Open(UIContext ctx) {
        Panel_Login panel = ctx.panel_Login;
        if (panel == null) {
            bool has = ctx.assetsContext.TryGetPanel("Panel_Login", out GameObject prefab);
            if (!has) {
                Debug.LogError("Panel_Login not found");
                return;
            }

            panel = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Login>();
            panel.Ctor();
            panel.OnClickLoginHandle = () => {
                ctx.uiEvent.Panel_Login_LoginClick();
            };
            ctx.panel_Login = panel;
        }

        panel.Show();
    }

    public static void Panel_Login_Close(UIContext ctx) {
        Panel_Login panel = ctx.panel_Login;
        if (panel == null) {
            return;
        }
        panel.TearDown();
    }


    public static void Panel_Point_Open(UIContext ctx) {
        Panel_Point panel = ctx.panel_Point;
        if (panel == null) {
            bool has = ctx.assetsContext.TryGetPanel("Panel_Point", out GameObject prefab);
            if (!has) {
                Debug.LogError("Panel_Point not found");
                return;
            }

            panel = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Point>();
            panel.Ctor();
            panel.OnClickModifyNameHandle = () => {
                ctx.uiEvent.Panel_PointModifyNameClick();

            };
            panel.OnClickAdvanceHandle = () => {
                ctx.uiEvent.Panel_PointAdvanceClick();
            };
            panel.OnClickMiniGameHandle = () => {
                ctx.uiEvent.Panel_PointMiniGameClick();
            };
            panel.OnClickBrainHandle = () => {
                ctx.uiEvent.Panel_PointBrainClick();
            };


            ctx.panel_Point = panel;

            Panel_Point_UpdateName(ctx);
        }

        panel.Show();
    }

    public static void Panel_Point_UpdateName(UIContext ctx) {
        Panel_Point panel = ctx.panel_Point;

        panel.SetName(PlayerPrefs.GetString("name"));
    }

    public static void Panel_Point_SetName(UIContext ctx, string name) {

        Panel_Point panel = ctx.panel_Point;
        panel.SetName(name);
        PlayerPrefs.SetString("name", name);

    }

    public static void Panel_Point_Close(UIContext ctx) {
        Panel_Point panel = ctx.panel_Point;
        if (panel == null) {
            return;
        }
        panel.TearDown();
    }

    public static void Panel_ModifyName_Open(UIContext ctx) {
        Panel_ModifyName panel = ctx.panel_ModifyName;
        if (panel == null) {
            bool has = ctx.assetsContext.TryGetPanel("Panel_ModifyName", out GameObject prefab);
            if (!has) {
                Debug.LogError("Panel_ModifyName not found");
                return;
            }

            panel = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_ModifyName>();
            panel.Ctor();
            panel.OnbtnConfirmHandle = (inputName) => {
                ctx.uiEvent.Panel_ModifyName_ConfirmClick(inputName);
            };

            panel.OnbtnCancelHandle = () => {
                ctx.uiEvent.Panel_ModifyName_CancelClick();
            };
            ctx.panel_ModifyName = panel;
        }

        panel.Show();
    }



    public static void Panel_ModifyName_Close(UIContext ctx) {
        Panel_ModifyName panel = ctx.panel_ModifyName;
        if (panel == null) {
            return;
        }
        panel.TearDown();
    }

    public static void Panel_SelectCard_Open(UIContext ctx) {
        Panel_SelectCard panel = ctx.panel_SelectCard;

        if (panel == null) {
            bool has = ctx.assetsContext.TryGetPanel("Panel_SelectCard", out GameObject prefab);
            if (!has) {
                Debug.LogError("Panel_SelectCard not found");
                return;
            }
            panel = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_SelectCard>();
            panel.Ctor();
            panel.panel_ClickBeginGameHandle = () => {
                ctx.uiEvent.panel_ClickBeginGameHandle();
            };
            ctx.panel_SelectCard = panel;
        }

        panel.Show();
    }

    public static void Panel_SelectCard_AddCardElement(UIContext ctx, int typeID) {
        Panel_SelectCard panel = ctx.panel_SelectCard;
        panel.AddCardElement(ctx, typeID);
    }


    public static void Panel_SelectCard_AddCardElement(UIContext ctx, Panel_GoodsElement card) {

        Panel_SelectCard panel = ctx.panel_SelectCard;
        panel.AddCardElement(ctx, card.typeID);

    }

    public static void Panel_SelectCard_Close(UIContext ctx) {
        Panel_SelectCard panel = ctx.panel_SelectCard;
        if (panel == null) {
            return;
        }
        int lenCards = ctx.goodsRespository.TakeAll(out Panel_GoodsElement[] cards);

        for (int i = 0; i < lenCards; i++) {
            Panel_GoodsElement card = cards[i];
            if (card.cardType == CardType.SelectCard) {
                ctx.goodsRespository.Remove(card);
            }
        }
        panel.TearDown();
    }




}