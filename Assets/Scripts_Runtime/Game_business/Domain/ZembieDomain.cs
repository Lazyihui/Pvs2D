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
        entity.Ctor();

        entity.OntriggerEnter2DHandle = (entity, other) => {
            OnTouchEnter(ctx, entity, other);
        };

        entity.OntriggerExit2DHandle = (entity, other) => {
            OnTouchExit(ctx, entity, other);
        };

        entity.hp = 100;
        entity.hpMax = 100;



        entity.isAttack = false;

        ctx.zembieRepository.Add(entity);

        return entity;

    }


    static void OnTouchEnter(GameContext ctx, ZembieEntity entity, Collider2D other) {
        // 用标签判断是否有植物
        if (other.CompareTag("Plant")) {
            entity.isAttack = true;
            Debug.Log("ZembieEntity OnTouchEnter");
        }
    }



    static void OnTouchExit(GameContext ctx, ZembieEntity entity, Collider2D other) {
        Debug.Log("ZembieEntity OnTouchExit");
    }
    public static void Move(GameContext ctx, ZembieEntity entity) {
        if (entity.isAttack) {
            return;
        }

        entity.move();

    }


}