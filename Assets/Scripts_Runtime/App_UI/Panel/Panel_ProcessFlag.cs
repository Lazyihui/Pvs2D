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

    public Vector2 startPos;

    // head 特有
    public bool isAchieveFlag;
    // flag 特有
    public bool isUpFlag;



    public void Ctor() {
        t = 0;
        startPos = rectTransform.anchoredPosition;
        isUpFlag = false;
        isAchieveFlag = false;
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

        // TODO: 要根据flag的数量来计算 要改的
        if (t / total > 0.5f) {
            isAchieveFlag = true;
        }

        if (t / total > 1) {
            isAchieveFlag = true;
        }

        if (isAchieveFlag) {
            return;
        }

        pos.x = -(t / total) * mstHead.width;
        mstHead.rectTransform.anchoredPosition = pos;
    }

    public void SetFlagPos(Panel_ProcessFlag flag, float flagCount) {
        Vector2 pos = flag.rectTransform.anchoredPosition;

        pos.x = -flag.width * ((float)flag.id / flagCount);
        // pos.x = -flag.width*0.5f;

        flag.rectTransform.anchoredPosition = pos;


    }

    public void FlagUp(Panel_ProcessFlag flag, float dt) {
        // Vector2 pos = flag.rectTransform.anchoredPosition;
        // if (pos.y > 30) {
        //     flag.rectTransform.anchoredPosition = pos;
        //     return;
        // }
        // pos.y = +dt;
        // Debug.Log("flagUp" + pos.y);
        // flag.rectTransform.anchoredPosition = pos;


        Vector2 pos = flag.rectTransform.anchoredPosition;
        pos.y = pos.y + 30;
        flag.rectTransform.anchoredPosition = pos;

    }


    public void Show() {
        this.gameObject.SetActive(true);
    }

    public void TearDown() {
        GameObject.Destroy(this.gameObject);
    }
}