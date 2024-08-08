using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlantEntity : MonoBehaviour {

    [SerializeField] Animator anim;



    public int id;

    public int typeID;

    public PlantStatus plantStatus;


    public void Ctor() {
        plantStatus = PlantStatus.Disable;
    }

    public void SetAnim(Animator animator) {
        anim = animator;
    }


    public void SetStatus(PlantEntity plant) {
        if (plant.plantStatus == PlantStatus.Disable) {
            // plant.plantStatus = PlantStatus.Enable;
            // anim.Play("PlantEntity_Enable");
        } else if (plant.plantStatus == PlantStatus.Enable) {
            // plant.plantStatus = PlantStatus.Disable;
            // anim.Play("PlantEntity_Disable");
        } else {

        }
    }


    void Disable() { }

    void Enable() { }

}