using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Panel_SelectCard : MonoBehaviour {

    [SerializeField] Panel_GoodsElement cardElementPrefab;

    public void Show() {
        gameObject.SetActive(true);
    }
    public void TearDown() {
        Destroy(gameObject);
    }
}