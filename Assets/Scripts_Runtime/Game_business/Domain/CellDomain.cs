using System;
using UnityEngine;


public static class CellDomain {

    public static CellEntity Spawn(GameContext ctx) {
        bool has = ctx.assetsContext.TryGetEntity("Cell_Entity", out GameObject prefab);
        if (!has) {
            Debug.LogError("Cell_Entity prefab not found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab, ctx.CellGroup);
        CellEntity entity = go.GetComponent<CellEntity>();
        entity.Ctor();
        entity.id = ctx.idService.cellIDRecord++;

        ctx.cellRepository.Add(entity);
        return entity;

    }


}