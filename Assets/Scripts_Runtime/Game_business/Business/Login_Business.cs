using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LoginBusiness {


    public static void Enter(GameContext ctx) {

        //UIApp
        UIApp.Panel_Goods_Open(ctx.uiContext);

        UIApp.Panel_GoodsElementAdd(ctx.uiContext, 0);
        UIApp.Panel_GoodsElementAdd(ctx.uiContext, 1);
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

        ctx.moduleCamera.MovetRight(new Vector3(5, 0, -10), dt);
        ctx.moduleCamera.MoveLeft(new Vector3(0, 0, -10), dt);

        if (ctx.moduleCamera.isAchieveRight && ctx.moduleCamera.isAchieveLeft) {
            UIApp.Panel_Prepare_Open(ctx.uiContext);
            UIApp.Panel_Prepare_Update(ctx.uiContext, dt);
        }


        bool has = UIApp.Panel_Prepare_Close(ctx.uiContext);

        if (has) {
            ctx.gameEntity.gameStatus = GameStatus.GameBusiness;
        }

    }

    private static void LogicFix(GameContext ctx, float dt) {


    }

    private static void LateTick(GameContext ctx, float dt) {
    }




}