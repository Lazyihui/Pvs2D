using System;

using System.Collections.Generic;



public class BulletRepository {

    Dictionary<int, BulletEntity> all;

    BulletEntity[] temArray;

    public BulletRepository() {
        all = new Dictionary<int, BulletEntity>();
        temArray = new BulletEntity[1000];
    }

    public void Add(BulletEntity entity) {
        all.Add(entity.id, entity);
    }
    public void Remove(BulletEntity entity) {
        all.Remove(entity.id);
    }
    public int TakeAll(out BulletEntity[] array) {
        if (all.Count > temArray.Length) {
            temArray = new BulletEntity[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }
    //委托 Predicate<BulletEntity> Action<>
    public BulletEntity Find(Predicate<BulletEntity> predicate) {
        foreach (BulletEntity Bullet in all.Values) {
            bool isMatch = predicate(Bullet);

            if (isMatch) {
                return Bullet;
            }
        }
        return null;
    }

}
