using System;

using System.Collections.Generic;



public class ZembieHeadRepository {

    Dictionary<int, ZembieHeadEntity> all;

    ZembieHeadEntity[] temArray;

    public ZembieHeadRepository() {
        all = new Dictionary<int, ZembieHeadEntity>();
        temArray = new ZembieHeadEntity[1000];
    }

    public void Add(ZembieHeadEntity entity) {
        all.Add(entity.id, entity);
    }
    public void Remove(ZembieHeadEntity entity) {
        all.Remove(entity.id);
    }
    public int TakeAll(out ZembieHeadEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new ZembieHeadEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }
    //委托 Predicate<ZembieHeadEntity> Action<>
    public ZembieHeadEntity Find(Predicate<ZembieHeadEntity> predicate) {
        foreach (ZembieHeadEntity ZembieHead in all.Values) {
            bool isMatch = predicate(ZembieHead);

            if (isMatch) {
                return ZembieHead;
            }
        }
        return null;
    }

}
