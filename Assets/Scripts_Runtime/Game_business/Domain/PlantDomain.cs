using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public static class PlantDomain {


    public static PlantEntity Spawn(GameContext ctx, int typeID) {

        bool has = ctx.assetsContext.TryGetEntity("Plant_Entity", out GameObject prefab);
        if (!has) {
            Debug.LogError("PlantEntity prefab not found");
            return null;
        }

        GameObject go = GameObject.Instantiate(prefab);
        PlantEntity plant = go.GetComponent<PlantEntity>();
        plant.Ctor();
        // plant.SetPos(new Vector2(0, 0));
        plant.typeID = typeID;
        plant.needSunCount = 50;

        plant.spawnInterval = 5;
        plant.spawnTimer = 0;



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
        plant.spawnTimer += dt;
        if (plant.spawnTimer >= plant.spawnInterval) {
            //播动画
            Debug.Log("11111生成阳光");

            plant.AnimSetTrigger();

            // 生成阳光
            BulletEntity sun = BulletDomain.Spawn(ctx, plant.transform.position, 1);

            float distance = UnityEngine.Random.Range(sun.jumpMinDistance, sun.jumpMaxDistance);
            float angle = UnityEngine.Random.Range(0, 2);
            if (angle < 1) {
                distance = -distance;
            }

            Vector2 pos = sun.transform.position;
            pos.x += distance;

            sun.JumpTo(pos);

            plant.spawnTimer = 0;


        }


    }



}