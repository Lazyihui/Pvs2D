using System;
using UnityEngine;


public static class BulletDomain {
    public static BulletEntity Spawn(GameContext ctx, Vector2 pos, int typeID) {
        bool has = ctx.assetsContext.TryGetEntity("Bullet_Entity", out GameObject prefab);
        if (!has) {
            Debug.LogError("Bullet_Entity prefab not found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        BulletEntity entity = go.GetComponent<BulletEntity>();

        entity.id = ctx.idService.bulletIDRecord++;
        entity.typeID = typeID;
        entity.Cotr();
        entity.SetPos(pos);
        entity.jumpMaxDistance = 1.5f;
        entity.jumpMinDistance = 0.5f;

        entity.OnClickCardHandle = () => {
            addSunCount(ctx, entity);
        };

        ctx.bulletRepository.Add(entity);

        return entity;
    }

    public static void SunSpawnedMove(GameContext ctx, BulletEntity sun) {
        if (sun.typeID != BulletConst.Sun) {
            return;
        }

        float distance = UnityEngine.Random.Range(sun.jumpMinDistance, sun.jumpMaxDistance);
        float angle = UnityEngine.Random.Range(0, 2);
        if (angle < 1) {
            distance = -distance;
        }
        Vector2 pos = sun.transform.position;
        pos.x += distance;

        sun.JumpTo(pos);
    }

    static void SunMoveToText(GameContext ctx, BulletEntity sun) {
        if (sun.typeID != BulletConst.Sun) {
            return;
        }


        sun.MoveToTaget(ctx.gameEntity.textWorldPos);

    }

    static void addSunCount(GameContext ctx, BulletEntity bullet) {

        if (bullet.typeID != BulletConst.Sun) {
            return;
        }
        ctx.idService.sunCount += 25;
        SunMoveToText(ctx, bullet);
    }
}