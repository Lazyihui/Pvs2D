using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Process : MonoBehaviour {

    public float width;



    public void Ctor() {

        width = 321;

    }


    public void AddProcess(UIContext ctx, int typeID) {
        
    }

    public void Show() {
        this.gameObject.SetActive(true);
    }

    public void TearDown() {
        GameObject.Destroy(this.gameObject);
    }



}