using System;

using System.Collections.Generic;



public class ZembieRepository {

    Dictionary<int, ZembieEntity> all;

    ZembieEntity[] temArray;

    public ZembieRepository() {
        all = new Dictionary<int, ZembieEntity>();
        temArray = new ZembieEntity[1000];
    }

    public void Add(ZembieEntity entity) {
        all.Add(entity.id, entity);
    }
    public void Remove(ZembieEntity entity) {
        all.Remove(entity.id);
    }
    public int TakeAll(out ZembieEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new ZembieEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }
    //委托 Predicate<ZembieEntity> Action<>
    public ZembieEntity Find(Predicate<ZembieEntity> predicate) {
        foreach (ZembieEntity Zembie in all.Values) {
            bool isMatch = predicate(Zembie);

            if (isMatch) {
                return Zembie;
            }
        }
        return null;
    }

}
