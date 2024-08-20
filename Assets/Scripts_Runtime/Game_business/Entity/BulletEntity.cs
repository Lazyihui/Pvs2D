using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BulletEntity : MonoBehaviour {

    [SerializeField] public Animator anim;

    public int id;

    public int typeID;

    // sun
    public float jumpMinDistance;

    public float jumpMaxDistance;

    public Vector2 sunSpawnPosTarget;


    public float atkValue;

    public float moveSpeed;

    public void Cotr() {

    }

    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }

    public void SetAnim(RuntimeAnimatorController animator) {
        anim.runtimeAnimatorController = animator;
    }
    public void JumpTo(Vector2 targetPos) {

        if (this == null) {
            return;
        }

        Vector2 centerPos = (targetPos + (Vector2)transform.position) / 2;
        float distance = Vector2.Distance(targetPos, transform.position);

        centerPos.y += (distance * 0.5f);



        transform.DOPath(new Vector3[] { transform.position, centerPos, targetPos }, 2,
        PathType.CatmullRom).SetEase(Ease.OutQuart);


    }

    public void MoveToTaget(Vector2 targetPos, float dt) {


        Vector2 pos = transform.position;

        Vector2 dir = (targetPos - pos).normalized;
        pos += dir * dt * moveSpeed;

        transform.position = pos;


    }
    public void TearDown(float time) {
        Destroy(gameObject, time);
    }


}