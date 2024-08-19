using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Panel_Prepare : MonoBehaviour {

    [SerializeField] Image start;

    [SerializeField] Image place;

    [SerializeField] Image plant;


    public float startTimer;

    public float placeTimer;

    public float plantTimer;

    public bool isFinish;

    public void Ctor() {
        startTimer = 0;
        placeTimer = 0;
        plantTimer = 0;

        start.gameObject.SetActive(true);
        place.gameObject.SetActive(false);
        plant.gameObject.SetActive(false);

        isFinish = false;

    }

    public void Panel_Update(float dt) {
        if (isFinish) {
            plant.gameObject.SetActive(false);
            return;
        }

        placeTimer += dt;
        plantTimer += dt;


        if (placeTimer >= 1) {
            start.gameObject.SetActive(false);
            place.gameObject.SetActive(true);
        }

        if (plantTimer >= 2) {
            place.gameObject.SetActive(false);
            plant.gameObject.SetActive(true);
        }
        if (plantTimer >= 3) {
            isFinish = true;
        }
    }
    public void TearDown() {
        GameObject.Destroy(this.gameObject);
    }


}