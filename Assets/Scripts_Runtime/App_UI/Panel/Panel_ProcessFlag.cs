using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Panel_ProcessFlag : MonoBehaviour {

    [SerializeField] Image image;
    [SerializeField] RectTransform rectTransform;
    public int id;

    public int typeID;
    public float width;


    public float t;

    public float total;
    public void Ctor() {
        t = 0;
        total = 10;
    }

    public void SetPos(Vector2 pos) {
        // RectTransform rt = this.GetComponent<RectTransform>();
        // rt.anchoredPosition = pos;

        rectTransform.anchoredPosition = pos;

    }

    public void SetImage(Sprite sprite) {
        image.sprite = sprite;
        image.SetNativeSize();

    }

    public void SetWidth(float width) {
        this.width = width;

        //9.8 这里可能要改
        // RectTransform rt = this.GetComponent<RectTransform>();
        // rt.sizeDelta = new Vector2(width, rt.sizeDelta.y);
    }

    public void Move_ToFlag(ref float t, float total, float dt, Panel_ProcessFlag mstHead) {
        t += dt;
        Vector2 pos = mstHead.rectTransform.anchoredPosition;
        Debug.Log("pos" + pos);

        pos.x = (t / total) * mstHead.width;

        mstHead.rectTransform.anchoredPosition = pos;

        // Debug.Log("t=" + t + "total" + total);

    }



    public void Show() {
        this.gameObject.SetActive(true);
    }

    public void TearDown() {
        GameObject.Destroy(this.gameObject);
    }
}