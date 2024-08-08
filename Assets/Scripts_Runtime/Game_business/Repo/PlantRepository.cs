using System;

using System.Collections.Generic;



public class PlantRepository {

    Dictionary<int, PlantEntity> all;

    PlantEntity[] temArray;

    public PlantRepository() {
        all = new Dictionary<int, PlantEntity>();
        temArray = new PlantEntity[1000];
    }

    public void Add(PlantEntity entity) {
        all.Add(entity.id, entity);
    }
    public void Remove(PlantEntity entity) {
        all.Remove(entity.id);
    }
    public int TakeAll(out PlantEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new PlantEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }
    //委托 Predicate<PlantEntity> Action<>
    public PlantEntity Find(Predicate<PlantEntity> predicate) {
        foreach (PlantEntity Plant in all.Values) {
            bool isMatch = predicate(Plant);

            if (isMatch) {
                return Plant;
            }
        }
        return null;
    }

}
