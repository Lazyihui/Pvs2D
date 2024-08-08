using System;
using UnityEngine;

public static class UserInterfaceDomain {


    public static void UpdataHandPlantPos(GameContext ctx, PlantEntity plant) {

        if (plant.plantStatus == PlantStatus.Enable) {
            return;
        }

        plant.SetPos(ctx.moduleInput.mouseWorldPos);
    }

}
