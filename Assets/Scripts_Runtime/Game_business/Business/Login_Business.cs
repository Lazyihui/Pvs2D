using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LoginBusiness {


    public static void Enter(GameContext ctx) {

        //UIApp
        UIApp.Panel_Goods_Open(ctx.uiContext);
        //  第一关
        ZembieDomain.Spawn(ctx, new Vector2(9, 3.32f), 0);
        ZembieDomain.Spawn(ctx, new Vector2(10, -1.32f), 0);

        int lenzem = ctx.zembieRepository.TakeAll(out ZembieEntity[] zembies);

        for (int i = 0; i < lenzem; i++) {
            ZembieEntity zembie = zembies[i];

            zembie.SetAnim(0);

        }


    }


    public static void Load() {

    }


    public static void Unload() {

    }

    public static void Tick(GameContext ctx, float dt) {
        PreTick(ctx, dt);
        ref float restFixTime = ref ctx.gameEntity.restFixTime;
        restFixTime += dt;
        const float FIX_INTERVAL = 0.020f;
        if (restFixTime <= FIX_INTERVAL) {
            LogicFix(ctx, restFixTime);
            restFixTime = 0;
        } else {
            while (restFixTime >= FIX_INTERVAL) {
                restFixTime -= FIX_INTERVAL;
                LogicFix(ctx, FIX_INTERVAL);
            }
        }
        LateTick(ctx, dt);
    }

    private static void PreTick(GameContext ctx, float dt) {


        // 第一关卡

        bool hasMoveRight = ctx.moduleCamera.MovetRight(new Vector3(5, 0, -10), dt);



        if (hasMoveRight) {
            UIApp.Panel_SelectCard_Open(ctx.uiContext);
            UIApp.Panel_SelectCard_AddCardElement(ctx.uiContext, 0);
            UIApp.Panel_SelectCard_AddCardElement(ctx.uiContext, 0);
            UIApp.Panel_SelectCard_AddCardElement(ctx.uiContext, 0);
            UIApp.Panel_SelectCard_AddCardElement(ctx.uiContext, 1);
            UIApp.Panel_SelectCard_AddCardElement(ctx.uiContext, 1);
            UIApp.Panel_SelectCard_AddCardElement(ctx.uiContext, 1);
            UIApp.Panel_SelectCard_AddCardElement(ctx.uiContext, 1);
            UIApp.Panel_SelectCard_AddCardElement(ctx.uiContext, 1);
        }

        if (ctx.moduleCamera.isAchieveRight && ctx.moduleCamera.isAchieveLeft && ctx.gameEntity.isGameBegin) {
            UIApp.Panel_Prepare_Open(ctx.uiContext);
            UIApp.Panel_Prepare_Update(ctx.uiContext, dt);
        }

        // 要改
        ctx.moduleCamera.MoveLeft(new Vector3(0, 0, -10), dt);

        bool has = UIApp.Panel_Prepare_Close(ctx.uiContext);

        if (has) {
            GameBusiness.Enter(ctx);
            ctx.gameEntity.gameStatus = GameStatus.GameBusiness;
            int len = ctx.uiContext.goodsRespository.TakeAll(out Panel_GoodsElement[] goods);
            for (int i = 0; i < len; i++) {
                Panel_GoodsElement card = goods[i];
                if (card.cardType == CardType.SelectCard) {
                    return;
                }
                card.status = GoodStatus.Cooling;
            }


            Debug.Log("GameBusiness");
        }

        ////////////////////////////////////////

    }

    private static void LogicFix(GameContext ctx, float dt) {

        int lenCard = ctx.uiContext.goodsRespository.TakeAll(out Panel_GoodsElement[] cards);

        for (int i = 0; i < lenCard; i++) {
            Panel_GoodsElement card = cards[i];
            UIApp.Panel_CardsElement_SetStatus(ctx.uiContext, card, dt);
        }

    }

    private static void LateTick(GameContext ctx, float dt) {


    }




}