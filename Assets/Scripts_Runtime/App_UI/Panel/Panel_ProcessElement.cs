using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Panel_ProcessElement : MonoBehaviour {

    public int id;

    public int typeID;
    public float width;

    public void Ctor() { }

    public void SetWidth(float width) {
        this.width = width;
        RectTransform rt = this.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(width, rt.sizeDelta.y);
    }


    public void Show() {
        this.gameObject.SetActive(true);
    }

    public void TearDown() {
        GameObject.Destroy(this.gameObject);
    }
}