using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public static class PlantDomain {


    public static PlantEntity Spawn(GameContext ctx, int typeID) {

        bool has = ctx.templateContext.plants.TryGetValue(typeID, out PlantTM tm);



        ctx.assetsContext.TryGetEntity("Plant_Entity", out GameObject prefab);

        GameObject go = GameObject.Instantiate(prefab);
        go.GetComponent<Collider2D>().enabled = false;
        PlantEntity plant = go.GetComponent<PlantEntity>();

        plant.Ctor();
        plant.typeID = tm.typeID;

        plant.SetAnim(tm.animator, tm.sprite);
        plant.spawnBulletInterval = tm.spawnBulletInterval;
        plant.spawnBulletTimer = tm.spawnBulletTimer;

        plant.hp = tm.hp;
        plant.hpMax = tm.hpMax;



        plant.id = ctx.idService.plantIDRecord++;
        ctx.plantRepository.Add(plant);
        return plant; // 0x54

    }


    public static void SetStatus(GameContext ctx, PlantEntity plant, float dt) {

        if (plant.status == PlantStatus.Disable) {

        }

        if (plant.status == PlantStatus.Enable) {
            spawnSunflower(ctx, plant, dt);
            SpawnBullet(ctx, plant, dt);
        }

    }

    static void spawnSunflower(GameContext ctx, PlantEntity plant, float dt) {

        if (plant.typeID != PlantConst.SunFlower) {
            return;
        }

        // 生成阳光
        plant.spawnBulletTimer += dt;
        if (plant.spawnBulletTimer >= plant.spawnBulletInterval) {
            //播动画

            plant.AnimSetTrigger();

            // 生成阳光

            Vector2 pos = plant.transform.position;
            pos.y = pos.y - 0.5f;

            BulletEntity sun = BulletDomain.Spawn(ctx, pos, BulletConst.Sun);

            BulletDomain.SunSpawnedMove(ctx, sun);

            plant.spawnBulletTimer = 0;

            // 
        }

    }

    public static void TakeDamage(GameContext ctx, PlantEntity plant, int damage) {

        plant.hp -= damage;
        if (plant.hp <= 0) {
            plant.status = PlantStatus.Disable;
            ctx.plantRepository.Remove(plant);
            plant.TearDown();
        }
    }


    public static void SpawnBullet(GameContext ctx, PlantEntity plant, float dt) {

        if (plant.typeID == PlantConst.SunFlower) {
            return;
        }

        plant.spawnBulletTimer += dt;
        if (plant.spawnBulletTimer >= plant.spawnBulletInterval) {
            plant.spawnBulletTimer = 0;
            Vector2 pos = new Vector2(plant.transform.position.x + 0.5f, plant.transform.position.y + 0.3f);
            BulletEntity bullet = BulletDomain.Spawn(ctx, pos, BulletConst.shooter);
        }
    }

    public static void Clear(GameContext ctx, PlantEntity plant) {

        plant.anim.speed = 0;

    }
}