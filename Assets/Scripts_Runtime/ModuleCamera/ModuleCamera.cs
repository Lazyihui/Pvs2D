using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class ModuleCamera {

    public Camera camera;

    public bool isAchieveRight;

    public bool isAchieveLeft;
    public ModuleCamera() {
        isAchieveRight = false;
        isAchieveLeft = true;
    }

    public void Inject(Camera camera) {
        this.camera = camera;
    }


    public void MovetRight(Vector3 movePos, float dt) {
        if (isAchieveRight) {
            return;
        }

        Vector3 pos = camera.transform.position;
        pos += Vector3.right * dt * 2;
        camera.transform.position = pos;

        if (pos.x >= movePos.x) {
            pos.x = movePos.x;
            isAchieveRight = true;
            // 这里放到开始游戏的时候
            // isAchieveLeft = false;//
            isAchieveLeft = true;

        }
    }

    public void MoveLeft(Vector3 movePos, float dt) {

        if (isAchieveLeft) {
            return;
        }

        Vector3 pos = camera.transform.position;
        pos += Vector3.left * dt * 2;
        camera.transform.position = pos;

        if (pos.x <= movePos.x) {
            pos.x = movePos.x;
            isAchieveLeft = true;
        }


    }


}
