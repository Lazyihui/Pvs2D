using System;
using UnityEngine;
using DG.Tweening;

public static class BulletDomain {
    public static BulletEntity Spawn(GameContext ctx, Vector2 pos, int typeID) {

        bool has = ctx.templateContext.bullets.TryGetValue(typeID, out BulletTM tm);
        if (!has) {
            Debug.LogError("没有这个预制体");
            return null;
        }



        ctx.assetsContext.TryGetEntity("Bullet_Entity", out GameObject prefab);



        GameObject go = GameObject.Instantiate(prefab);
        BulletEntity entity = go.GetComponent<BulletEntity>();

        entity.id = ctx.idService.bulletIDRecord++;
        entity.typeID = typeID;
        entity.Cotr();
        entity.SetPos(pos);

        entity.SetAnim(tm.animator);

        entity.jumpMaxDistance = 1.5f;
        entity.jumpMinDistance = 0.5f;

        ctx.bulletRepository.Add(entity);

        return entity;
    }

    public static void SunSpawnedMove(GameContext ctx, BulletEntity sun) {
        if (sun.typeID != BulletConst.Sun) {
            return;
        }

        float distance = UnityEngine.Random.Range(sun.jumpMinDistance, sun.jumpMaxDistance);
        float angle = UnityEngine.Random.Range(0, 2);
        if (angle < 1) {
            distance = -distance;
        }
        Vector2 pos = sun.transform.position;
        pos.x += distance;

        sun.JumpTo(pos);
    }




    //第二种移动 但是有问题
    public static void MoveToTarget(GameContext ctx, BulletEntity sun, Vector2 targetPos, float dt) {
        sun.MoveToTaget(targetPos, dt);

        // Vector2 pos = sun.transform.position;


        // if (pos == targetPos) {
        //     ctx.bulletRepository.Remove(sun);
        //     sun.TearDown();
        // }


    }

    public static void MouseInBullet(GameContext ctx, BulletEntity bullet) {
        if (bullet.typeID == BulletConst.Sun || bullet.typeID == BulletConst.Sun_Fall) {

            Vector2 mousePos = ctx.moduleInput.mouseWorldPos;
            Vector2 pos = bullet.transform.position;

            float distance = Vector2.Distance(mousePos, pos);


            if (distance < 0.5f) {
                if (Input.GetMouseButtonDown(0)) {

                    addSunCount(ctx, bullet);

                }

            }
        }


    }


    static void addSunCount(GameContext ctx, BulletEntity bullet) {

        SunMoveToText(ctx, bullet);
    }

    static void SunMoveToText(GameContext ctx, BulletEntity sun) {

        Vector2 targetPos = ctx.gameEntity.textWorldPos;
        sun.transform.DOMove(targetPos, 0.5f).SetEase(Ease.OutQuart).OnComplete(() => {
            ctx.bulletRepository.Remove(sun);
            sun.TearDown();
            ctx.idService.sunCount += 25;

        });

    }
}