using System;
using UnityEngine;


public class ZembieHeadEntity : MonoBehaviour {
    public int typeID;

    public int id;


    public void Ctor() {
    }

    public void TearDown() {
        Destroy(gameObject, 1);
    }

}