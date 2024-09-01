using System;

using System.Collections.Generic;



public class MapRepository {

    Dictionary<int, MapEntity> all;

    MapEntity[] temArray;

    public MapRepository() {
        all = new Dictionary<int, MapEntity>();
        temArray = new MapEntity[1000];
    }

    public void Add(MapEntity entity) {
        all.Add(entity.id, entity);
    }
    public void Remove(MapEntity entity) {
        all.Remove(entity.id);
    }
    public int TakeAll(out MapEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new MapEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }
    //委托 Predicate<MapEntity> Action<>
    public MapEntity Find(Predicate<MapEntity> predicate) {
        foreach (MapEntity Map in all.Values) {
            bool isMatch = predicate(Map);

            if (isMatch) {
                return Map;
            }
        }
        return null;
    }

}
