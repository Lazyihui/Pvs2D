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

        entity.OnMouseDownHandle = () => {
            Plant(ctx, entity);
        };

        ctx.cellRepository.Add(entity);
        return entity;

    }


    public static void Plant(GameContext ctx, CellEntity cell) {
        if (ctx.gameEntity.handPlant == null || cell.isHavsPlant) {
            return;
        }

        cell.isHavsPlant = true;

        ctx.gameEntity.handPlant.transform.position = cell.transform.position;
        // 0x54 = 2
        ctx.gameEntity.handPlant.status = PlantStatus.Enable;
        ctx.gameEntity.handPlant.GetComponent<Collider2D>().enabled = true;
        ctx.gameEntity.handPlant.SetAnimSpeed(1);

        ctx.gameEntity.handPlant = null;

    }

}