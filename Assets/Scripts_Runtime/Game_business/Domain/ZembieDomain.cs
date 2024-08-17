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

        entity.OnCollisionEnter2DHandle = (entity, other) => {
            OnTouchEnter(ctx, entity, other);
        };

        entity.OnCollisionExit2DHandle = (entity, other) => {
            OnTouchExit(ctx, entity, other);
        };

        entity.hp = 100;
        entity.hpMax = 100;



        entity.isAttack = false;

        ctx.zembieRepository.Add(entity);

        return entity;

    }


    static void OnTouchEnter(GameContext ctx, ZembieEntity entity, Collision2D other) {
        // 用标签判断是否有植物
        if (other.gameObject.tag == "Plant") {
            PlantEntity plant = other.gameObject.GetComponent<PlantEntity>();
            if (plant == null) {
                return;
            }

            Debug.Log("ZembieEntity OnTouchEnter");
            entity.isAttack = true;

            entity.anim.SetBool("IsAttacking", true);


            // if (plant.status == PlantStatus.Disable) {
            //     return;
            // }

            // entity.isAttack = true;
            // plant.hp -= 10;
            // if (plant.hp <= 0) {
            //     plant.status = PlantStatus.Disable;
            //     plant.hp = 0;
            //     plant.GetComponent<Collider2D>().enabled = false;
            // }
        }

    }



    static void OnTouchExit(GameContext ctx, ZembieEntity entity, Collision2D other) {
    
        if (other.gameObject.tag == "Plant") {
            PlantEntity plant = other.gameObject.GetComponent<PlantEntity>();
            if (plant == null) {
                return;
            }

            Debug.Log("ZembieEntity OnTouchExit");
            entity.isAttack = false;
            entity.anim.SetBool("IsAttacking", false);
        }
    
    }
    public static void Move(GameContext ctx, ZembieEntity entity) {
        if (entity.isAttack) {
            return;
        }

        entity.move();

    }


}