
using System;
using UnityEngine;

public static class ZembieHeadDomain {

    public static ZembieHeadEntity Spawn(GameContext ctx, int typeID, Vector3 spawnPos) {


        bool has = ctx.assetsContext.entities.TryGetValue("ZembieHead_Entity", out GameObject prefab);
        if (!has) {
            Debug.LogError("ZembieHead_Entity prefab not found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab, spawnPos, Quaternion.identity);
        ZembieHeadEntity entity = go.GetComponent<ZembieHeadEntity>();

        entity.id = ctx.idService.zembieHeadRecordID++;
        entity.typeID = typeID;
        entity.Ctor();

        ctx.zembieHeadRepository.Add(entity);

        return entity;

    }

    public static void UnSpawn(GameContext ctx, ZembieHeadEntity entity) {
        ctx.zembieHeadRepository.Remove(entity);
        entity.TearDown();
    }
}