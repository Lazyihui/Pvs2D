using System;
using UnityEngine;
using DG.Tweening;

public class BulletEntity : MonoBehaviour {

    public int id;

    public int typeID;

    // sun
    public float jumpMinDistance;

    public float jumpMaxDistance;

    public void Cotr() { }

    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }
    public void JumpTo(Vector2 targetPos) {

        Vector2 centerPos = (targetPos + (Vector2)transform.position) / 2;
        float distance = Vector2.Distance(targetPos, transform.position);

        centerPos.y += (distance * 0.5f);

        transform.DOPath(new Vector3[] { transform.position, centerPos, targetPos }, 2,
        PathType.CatmullRom).SetEase(Ease.OutQuart);


    }

}