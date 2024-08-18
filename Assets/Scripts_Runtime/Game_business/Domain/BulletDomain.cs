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

        entity.atkValue = tm.atkValue;
        entity.moveSpeed = tm.moveSpeed;
        ctx.bulletRepository.Add(entity);

        return entity;
    }


    public static void AttackingZembie(GameContext ctx, BulletEntity bullet) {

        if (bullet.typeID == BulletConst.Sun || bullet.typeID == BulletConst.Sun_Fall) {
            return;
        }

        int zemlen = ctx.zembieRepository.TakeAll(out ZembieEntity[] zembies);
        for (int i = 0; i < zemlen; i++) {
            ZembieEntity zembie = zembies[i];

            float distance = Vector2.SqrMagnitude(zembie.transform.position - bullet.transform.position);
            if (distance < 0.1f) {

                ZembieDomain.TakeDamage(ctx, zembie, bullet.atkValue);

                BulletDomain.UnSpawn(ctx, bullet);
            }
        }

    }



    public static void UnSpawn(GameContext ctx, BulletEntity bullet) {
        bullet.anim.Play("PeaBullet_HitBoom");

        ctx.bulletRepository.Remove(bullet);
        bullet.TearDown();
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

    public static void MoveLeft(GameContext ctx, BulletEntity bullet, float dt) {
        if (bullet.typeID == BulletConst.Sun || bullet.typeID == BulletConst.Sun_Fall) {
            return;
        }
        Debug.Log("MoveRight");
        Vector2 pos = bullet.transform.position;
        pos -= dt * Vector2.left * bullet.moveSpeed;
        bullet.transform.position = pos;
    }


    //第二种移动 但是有问题
    public static void MoveToTarget(GameContext ctx, BulletEntity sun, Vector2 targetPos, float dt) {
        sun.MoveToTaget(targetPos, dt);


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