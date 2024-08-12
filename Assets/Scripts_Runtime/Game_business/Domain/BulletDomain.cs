using System;
using UnityEngine;


public static class BulletDomain {
    public static BulletEntity Spawn(GameContext ctx, int typeID) {
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

        ctx.bulletRepository.Add(entity);

        return entity;
    }
}