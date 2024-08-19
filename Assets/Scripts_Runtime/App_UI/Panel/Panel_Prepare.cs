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

    public void Ctor() {
        startTimer = 0;
        placeTimer = 0;
        plantTimer = 0;
    }



}