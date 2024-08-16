using System;
using System.Collections.Generic;
using UnityEngine;


public static class ZembieDomain {
    public static ZembieEntity Spawn(GameContext ctx, int typeID) {
        bool has = ctx.assetsContext.TryGetEntity("Zembie_Entity", out GameObject prefab);
        if (!has) {
            Debug.LogError("Zembie_Entity prefab not found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        ZembieEntity entity = go.GetComponent<ZembieEntity>();

        entity.id = ctx.idService.zembieRecordID++;
        entity.typeID = typeID;
        entity.hp = 100;
        entity.hpMax = 100;

        ctx.zembieRepository.Add(entity);

        return entity;

    }
}