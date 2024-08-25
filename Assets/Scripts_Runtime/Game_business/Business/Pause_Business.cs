using System;
using UnityEngine;


public static class Pause_Business {

    public static void Enter(GameContext ctx) { }


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


    static void PreTick(GameContext ctx, float dt) {

        UIApp.Panel_Goods_Close(ctx.uiContext);
    }

    static void LogicFix(GameContext ctx, float dt) {

        int zemLen = ctx.zembieRepository.TakeAll(out ZembieEntity[] zembies);
        for (int i = 0; i < zemLen; i++) {
            ZembieEntity zembie = zembies[i];

            ZembieDomain.Clear(ctx, zembie);
        }

        int bulletLen = ctx.bulletRepository.TakeAll(out BulletEntity[] bullets);
        for (int i = 0; i < bulletLen; i++) {
            BulletEntity bullet = bullets[i];

            BulletDomain.Clear(ctx, bullet);
        
        }

        int plantLen = ctx.plantRepository.TakeAll(out PlantEntity[] plants);
        for (int i = 0; i < plantLen; i++) {
            PlantEntity plant = plants[i];

            PlantDomain.Clear(ctx, plant);
        }

    }

    static void LateTick(GameContext ctx, float dt) {
    }


}