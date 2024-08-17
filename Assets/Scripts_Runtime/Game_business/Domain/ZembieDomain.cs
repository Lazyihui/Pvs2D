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
        entity.status = ZembieStatus.Move;
        entity.targetPlant = null;

        entity.atkValue = 30;
        entity.atkDuration = 2;
        entity.atkTimer = 0;

        entity.OnCollisionEnter2DHandle = (entity, other) => {
            OnTouchEnter(ctx, entity, other);
        };

        entity.OnCollisionExit2DHandle = (entity, other) => {
            OnTouchExit(ctx, entity, other);
        };

        entity.hp = 100;
        entity.hpMax = 100;



        ctx.zembieRepository.Add(entity);

        return entity;

    }


    public static void AttackingPlant(GameContext ctx, ZembieEntity zem, float dt) {
        if (zem.targetPlant == null) {
            return;
        }

        if (zem.targetPlant.hp <= 0) {
            zem.targetPlant = null;
            return;
        }
        zem.atkTimer += dt;
        Debug.Log(zem.atkTimer);
        if (zem.atkTimer >= zem.atkDuration) {
            PlantDomain.TakeDamage(ctx, zem.targetPlant, zem.atkValue);
            zem.atkTimer = 0;

        }

    }

    static void OnTouchEnter(GameContext ctx, ZembieEntity entity, Collision2D other) {
        // 用标签判断是否有植物
        if (other.gameObject.tag == "Plant") {
            entity.targetPlant = other.gameObject.GetComponent<PlantEntity>();
            if (entity.targetPlant == null) {
                return;
            }


            entity.anim.SetBool("IsAttacking", true);

            entity.status = ZembieStatus.Eat;

            // 扣血

        }

    }



    static void OnTouchExit(GameContext ctx, ZembieEntity entity, Collision2D other) {

        if (other.gameObject.tag == "Plant") {
            PlantEntity plant = other.gameObject.GetComponent<PlantEntity>();
            if (plant == null) {
                return;
            }

            Debug.Log("ZembieEntity OnTouchExit");
            entity.anim.SetBool("IsAttacking", false);
            entity.status = ZembieStatus.Move;
            entity.atkTimer = 0;
        }

    }
    public static void Move(GameContext ctx, ZembieEntity entity) {

        entity.move();

    }


}