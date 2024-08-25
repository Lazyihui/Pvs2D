using System;
using System.Collections;
using UnityEngine;



public static class Loading {


    public static void Load(GameContext ctx) {
        UIApp.Panel_Login_Open(ctx.uiContext);
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
        
    }

    private static void LogicFix(GameContext ctx, float dt) {


    }

    private static void LateTick(GameContext ctx, float dt) {
    }


}