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
        plant.id = ctx.idService.PlantIDRecord++;
        ctx.plantRepository.Add(plant);
        return plant;

    }
}