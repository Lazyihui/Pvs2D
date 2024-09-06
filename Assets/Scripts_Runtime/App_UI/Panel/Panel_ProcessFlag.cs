using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Panel_ProcessFlag : MonoBehaviour {

    [SerializeField] Image image;
    public int id;

    public int typeID;
    public float width;

    public void Ctor() {
    }

    public void SetPos(Vector2 pos) {
        RectTransform rt = this.GetComponent<RectTransform>();
        rt.anchoredPosition = pos;
        Debug.Log("SetPos"+rt.anchoredPosition);
    }

    public void SetImage(Sprite sprite) {
        image.sprite = sprite;
        image.SetNativeSize();

    }

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