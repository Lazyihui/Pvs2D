using System;
using System.Collections.Generic;
using UnityEngine;


public static class ZembieDomain {
    public static ZembieEntity Spawn(GameContext ctx, Vector2 pos, int typeID) {
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
        entity.SetPos(pos);

        entity.status = ZembieStatus.Move;
        entity.targetPlant = null;
        entity.haveHead = true;

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


    public static void TakeDamage(GameContext ctx, ZembieEntity entity, float damage) {
        if (entity.status == ZembieStatus.Die) {
            return;
        }

        entity.hp -= damage;
        float hpPercent = entity.hp / entity.hpMax;


        entity.anim.SetFloat("HpPercent", hpPercent);

        if (entity.hp <= 0) {
            entity.status = ZembieStatus.Die;
            entity.GetComponent<Collider2D>().enabled = false;

            //应该会出错 9.5没看到错的
            ZembieDomain.TearDown(ctx, entity);
        }



        if (hpPercent < 0.3f && entity.haveHead == true) {
            ZembieLostHead(ctx, entity);
        }
    }

    static void ZembieLostHead(GameContext ctx, ZembieEntity zembie) {

        ZembieHeadEntity go = ZembieHeadDomain.Spawn(ctx, 0, zembie.transform.position);

        ZembieHeadDomain.UnSpawn(ctx, go);
        zembie.haveHead = false;

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


    public static void Clear(GameContext ctx, ZembieEntity zembie) {
        zembie.ClearVelocity();
        zembie.anim.speed = 0;
    }

    public static void TearDown(GameContext ctx, ZembieEntity zembie) {
        ctx.zembieRepository.Remove(zembie);
        zembie.TearDown();

    }
}