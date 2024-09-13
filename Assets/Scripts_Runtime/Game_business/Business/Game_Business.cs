using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public static class GameBusiness {

    public static void Enter(GameContext ctx) {


        // 右边的关卡僵尸
        int lenzem = ctx.zembieRepository.TakeAll(out ZembieEntity[] zembies);

        for (int i = 0; i < lenzem; i++) {
            ZembieEntity zembie = zembies[i];
            ZembieDomain.TearDown(ctx, zembie);
        }

        // cell 
        // TODO: 45 要改的根据不同的地图有不同的值
        for (int i = 0; i < 45; i++) {
            CellDomain.Spawn(ctx);
        }

        UIApp.Panel_Process_Open(ctx.uiContext);
        UIApp.Panel_Process_AddFlag(ctx.uiContext, 0);
        UIApp.Panel_Process_AddFlag(ctx.uiContext, 1);
        UIApp.Panel_Process_AddFlag(ctx.uiContext, 1);

        int lenFlag = ctx.uiContext.flagRespository.TakeAll(out Panel_ProcessFlag[] flags);

        for (int i = 0; i < lenFlag; i++) {
            Panel_ProcessFlag flag = flags[i];
            UIApp.Panel_Process_SetFlagPos(ctx.uiContext, flag, 2);

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

        Camera camera = ctx.moduleCamera.camera;

        input.mouseWorldPos = camera.ScreenToWorldPoint(input.mouseScreenPos);

        Vector3 textPos = ctx.uiContext.panel_Goods.sunCountText.transform.position;
        textPos.z = 0;
        ctx.gameEntity.textWorldPos = camera.ScreenToWorldPoint(textPos);

        // 生成zembie
        // 第一波僵尸  5个 间隔 5s
        GameDomain.SpawnZembieTimer(ctx, dt);
        int lenZem = ctx.zembieRepository.TakeAll(out ZembieEntity[] zembies);

        if (lenZem == 0) {
            ctx.gameEntity.isAchieveFlag = false;
        }



    }

    static void LogicFix(GameContext ctx, float dt) {

        UIApp.Panel_GoodsUpdateSunCount(ctx.uiContext);

        GameDomain.SpawnSunTimer(ctx, dt);

        // 得到游戏进度的百分比
        GameDomain.GetGamePercent(ctx, dt);

        int goodlen = ctx.uiContext.goodsRespository.TakeAll(out Panel_GoodsElement[] goods);
        for (int i = 0; i < goodlen; i++) {
            Panel_GoodsElement good = goods[i];
            if (good.cardType == CardType.GoodCard) {
                UIApp.Panel_GoodsElement_SetStatus(ctx.uiContext, good, dt);
                if (Input.GetKeyDown(KeyCode.A)) {
                    Debug.Log(good.status);
                }
            }

        }

        int plantLen = ctx.plantRepository.TakeAll(out PlantEntity[] plants);
        for (int i = 0; i < plantLen; i++) {
            PlantEntity plant = plants[i];

            GameDomain.UpdataHandPlantPos(ctx, plant);

            if (plant.status == PlantStatus.Disable) {
            }

            if (plant.status == PlantStatus.Enable) {
                // 生成阳光
                PlantDomain.spawnSunflower(ctx, plant, dt);


                if (plant.typeID == PlantConst.PeaShooter) {
                    PlantDomain.RayTesthasZembie(ctx, plant, dt);

                }
            }



        }

        int bulletLen = ctx.bulletRepository.TakeAll(out BulletEntity[] bullets);
        for (int i = 0; i < bulletLen; i++) {
            BulletEntity bullet = bullets[i];
            if (bullet.typeID == BulletConst.Sun_Fall) {
                BulletDomain.MoveToTarget(ctx, bullet, bullet.sunSpawnPosTarget, dt);
            }

            BulletDomain.MouseInBullet(ctx, bullet);
            BulletDomain.MoveLeft(ctx, bullet, dt);

            BulletDomain.AttackingZembie(ctx, bullet);
            BulletDomain.Peashooterdisapper(ctx, bullet);

        }

        int zembieLen = ctx.zembieRepository.TakeAll(out ZembieEntity[] zembies);
        for (int i = 0; i < zembieLen; i++) {
            ZembieEntity zembie = zembies[i];

            if (zembie.status == ZembieStatus.Move) {

                ZembieDomain.Move(ctx, zembie);

            } else if (zembie.status == ZembieStatus.Eat) {

                ZembieDomain.AttackingPlant(ctx, zembie, dt);
            } else if (zembie.status == ZembieStatus.Pause) {

                // ZembieDomain.Pause(ctx, zembie);

            }

        }


        int lenFlag = ctx.uiContext.flagRespository.TakeAll(out Panel_ProcessFlag[] flags);
        Panel_ProcessFlag head = flags[0];
        for (int i = 0; i < lenFlag; i++) {
            Panel_ProcessFlag flag = flags[i];
            float percent = ctx.gameEntity.percent;


            if (!ctx.gameEntity.isAchieveFlag) {
                UIApp.Panel_Process_HeadMove(ctx.uiContext, flag, percent, dt);
            }

            if (Input.GetKeyDown(KeyCode.A)) {
                Debug.Log(percent);
            }

            if (percent >= 0.5f) {
                if (flag.id == 1) {
                    ctx.gameEntity.isAchieveFlag = true;
                    UIApp.Panel_Process_FlagUp(ctx.uiContext, flag, dt);
                }
            }


        }




    }

    static void LateTick(GameContext ctx, float dt) {

        GameDomain.EnterGameOver(ctx);


    }
}