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

    public Vector2 startPos;

    // flag 特有
    public bool isUpFlag;



    public void Ctor() {
        startPos = rectTransform.anchoredPosition;
        isUpFlag = false;
    }

    public void SetImage(Sprite sprite) {
        image.sprite = sprite;
        image.SetNativeSize();

    }

    public void SetWidth(float width) {
        this.width = width;
    }

    public void Move_ToFlag(float percent, float dt, Panel_ProcessFlag mstHead) {


        Vector2 pos = mstHead.rectTransform.anchoredPosition;
        pos.x = -(percent) * mstHead.width;
        mstHead.rectTransform.anchoredPosition = pos;
    }

    public void SetFlagPos(Panel_ProcessFlag flag, float flagCount) {

        Vector2 pos = flag.rectTransform.anchoredPosition;
        pos.x = -flag.width * ((float)flag.id / flagCount);
        flag.rectTransform.anchoredPosition = pos;

    }

    public void FlagUp(Panel_ProcessFlag flag, float dt) {
        Vector2 pos = flag.rectTransform.anchoredPosition;

        if (pos.y > 30) {
            flag.rectTransform.anchoredPosition = pos;
            return;
        }
        pos.y += dt * 10;
        flag.rectTransform.anchoredPosition = pos;


    }


    public void Show() {
        this.gameObject.SetActive(true);
    }

    public void TearDown() {
        GameObject.Destroy(this.gameObject);
    }
}