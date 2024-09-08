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

    public static void SpawnZembieTimer(GameContext ctx, float dt) {

        ctx.gameEntity.zembieSpawnTimer += dt;

        if (ctx.gameEntity.zembieSpawnTimer >= 10) {
            ctx.gameEntity.zembieSpawnTimer = 0;
            int index = UnityEngine.Random.Range(0, ctx.gameEntity.zembieSpawnPos.Length);
            Vector2 pos = ctx.gameEntity.zembieSpawnPos[index];
            ZembieEntity zembie = ZembieDomain.Spawn(ctx, pos, 0);
            zembie.SetSpriteLayer(index);
        }
    }


    public static void EnterGameOver(GameContext ctx) {
        int mstlen = ctx.zembieRepository.TakeAll(out ZembieEntity[] zembies);
        for (int i = 0; i < mstlen; i++) {
            ZembieEntity zembie = zembies[i];


            // 如果有必要这里可以改成用BoxCollider2D来判断
            if (zembie.transform.position.x < -5.9f) {
                UIApp.Panel_Over_Open(ctx.uiContext);
                ctx.gameEntity.gameStatus = GameStatus.Pause;
                break;
            }

        }

    }



}
