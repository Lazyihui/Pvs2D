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

    public Vector2 startPos;
    public void Ctor() {
        t = 0;
        total = 10;
        startPos = rectTransform.anchoredPosition;
    }

    public void SetImage(Sprite sprite) {
        image.sprite = sprite;
        image.SetNativeSize();

    }

    public void SetWidth(float width) {
        this.width = width;
    }

    public void Move_ToFlag(ref float t, float total, float dt, Panel_ProcessFlag mstHead) {
        t += dt;
        Vector2 pos = mstHead.rectTransform.anchoredPosition;

        pos.x = -(t / total) * mstHead.width;
        mstHead.rectTransform.anchoredPosition = pos;
    }

    public void SetFlagPos(Panel_ProcessFlag flag,float flagCount) {
        Vector2 pos = flag.rectTransform.anchoredPosition;

        pos.x = -flag.width*((float)flag.id/flagCount);
        // pos.x = -flag.width*0.5f;

        flag.rectTransform.anchoredPosition = pos;
        

    }


    public void Show() {
        this.gameObject.SetActive(true);
    }

    public void TearDown() {
        GameObject.Destroy(this.gameObject);
    }
}