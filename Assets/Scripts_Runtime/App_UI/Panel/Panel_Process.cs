using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Process : MonoBehaviour {



    public void Ctor() { }


    public void Show() {
        this.gameObject.SetActive(true);
    }

    public void TearDown() {
        GameObject.Destroy(this.gameObject);
    }


}