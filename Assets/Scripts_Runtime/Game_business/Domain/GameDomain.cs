using System;
using UnityEngine;

public static class GameDomain {


    public static void UpdataHandPlantPos(GameContext ctx, PlantEntity plant) {

        if (plant.status == PlantStatus.Enable) {
            return;
        }

        plant.SetPos(ctx.moduleInput.mouseWorldPos);
    }


    public static void SpawnSunTimer(GameContext ctx, float dt) {

        ctx.gameEntity.sunSpawnTimer += dt;

        if (ctx.gameEntity.sunSpawnTimer >= ctx.gameEntity.sunSpawnInterval) {
            ctx.gameEntity.sunSpawnTimer = 0;

            // 生成阳光
            float x = UnityEngine.Random.Range(-4, 5.5f);

            BulletEntity sun = BulletDomain.Spawn(ctx, new Vector2(x, 6), BulletConst.Sun_Fall);
            float y = UnityEngine.Random.Range(-4, 2.5f);

            sun.sunSpawnPosTarget = new Vector2(x, y);
        }

    }



}