using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public static class GameBusiness {

    public static void Enter(GameContext ctx) {


    }

    public static void Load() {

    }

    public static void Unload() {

    }

    public static void Tick(GameContext ctx, float dt) {
        PreTick(ctx, dt);

        ref float restFixTime = ref ctx.gameEntity.restFixTime;

        restFixTime += dt;
        // ref传进去的参数在函数内部可以直接使用，而out不可（除非在函数体内部，out参数在使用之前赋值）
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
        //  初始化input   要种在世界坐标上
       ModuleInput input = ctx.moduleInput;
        input.mouseScreenPos = Input.mousePosition;

        Camera camera = ctx.camera;
        input.mouseWorldPos = camera.ScreenToWorldPoint(input.mouseScreenPos);


    }

    static void LogicFix(GameContext ctx, float dt) {
    }

    static void LateTick(GameContext ctx, float dt) {

    }
}