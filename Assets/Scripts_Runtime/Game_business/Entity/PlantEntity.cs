using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlantEntity : MonoBehaviour {

    [SerializeField] Animator anim; // ulong



    public int id;

    public int typeID;

    public PlantStatus status; // int

    // 时间什么的

    public float spawnInterval;

    public float spawnTimer;

    public void Ctor() {
        status = PlantStatus.Disable;
    }

    public void SetAnim(Animator animator) {
        anim = animator;
    }

    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }


    public void AnimSetTrigger() {
        anim.SetTrigger("IsGlowing");
    }

    // public void SetStatus(PlantEntity plant) {
    //     if (plant.status == PlantStatus.Disable) {
    //         // plant.plantStatus = PlantStatus.Enable;
    //         // anim.Play("PlantEntity_Enable");
    //     } else if (plant.status == PlantStatus.Enable) {
    //         // plant.plantStatus = PlantStatus.Disable;
    //         // anim.Play("PlantEntity_Disable");
    //     } else {

    //     }
    // }

    // void Disable() { }

    // void Enable() { }


}