using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public static class PlantDomain {


    public static PlantEntity Spawn(GameContext ctx, int typeID) {

        bool has = ctx.templateContext.plants.TryGetValue(typeID, out PlantTM tm);



        ctx.assetsContext.TryGetEntity("Plant_Entity", out GameObject prefab);

        GameObject go = GameObject.Instantiate(prefab);
        PlantEntity plant = go.GetComponent<PlantEntity>();
        plant.Ctor();
        // plant.SetPos(new Vector2(0, 0));
        plant.typeID = tm.typeID;

        plant.spawnBulletInterval = tm.spawnBulletInterval;
        plant.spawnBulletTimer = tm.spawnBulletTimer;



        plant.id = ctx.idService.plantIDRecord++;
        ctx.plantRepository.Add(plant);
        return plant; // 0x54

    }


    public static void SetStatus(GameContext ctx, PlantEntity plant, float dt) {

        if (plant.status == PlantStatus.Disable) {

        }

        if (plant.status == PlantStatus.Enable) {
            spawnSunflower(ctx, plant, dt);
        }

    }

    static void spawnSunflower(GameContext ctx, PlantEntity plant, float dt) {
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



}