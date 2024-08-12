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

    public static void addSunCount(GameContext ctx, BulletEntity bullet) {

        // 要改
        if (bullet.typeID != BulletConst.Sun) {
            return;
        }

        ctx.idService.sunCount += 25;
        bullet.TearDown();
        ctx.bulletRepository.Remove(bullet);
    }
}