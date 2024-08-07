using System;
using UnityEngine;
using UnityEngine.UI;


public class Panel_GoodsElement : MonoBehaviour {
    [SerializeField] Button button;

    [SerializeField] Image spriteLight;

    [SerializeField] Image spriteDark;

    [SerializeField] Image cardMask;

    public int id;

    public GoodStatus status;


    public Action OnClickCardHandle;

    public float cdTime;

    public float cdTimer;

    public void Init(Sprite spriteLight, Sprite spriteDark) {
        this.spriteLight.sprite = spriteLight;
        this.spriteDark.sprite = spriteDark;
    }

    public void Ctor() {
        status = GoodStatus.Cooling;
        cdTime = 2;
        cdTimer = 0;
    }


    public void SetStatus(GoodStatus status, float dt) {
        this.status = status;
        switch (status) {
            case GoodStatus.Cooling:
                Cooling(dt);
                break;
            case GoodStatus.WaitingSun:
                WaitingSun();
                break;
            case GoodStatus.Ready:
                Ready();
                break;
            default:
                break;
        }
    }

    void Cooling(float dt) {
        // 冷却
        cdTimer += dt;
        cardMask.fillAmount = (cdTime - cdTimer) / cdTime;
        if (cdTimer >= cdTime) {
            WaitingSun();
        }



        spriteLight.gameObject.SetActive(false);
        spriteDark.gameObject.SetActive(true);


        // button.interactable = false;
    }

    void WaitingSun() {
        status = GoodStatus.WaitingSun;

        spriteLight.gameObject.SetActive(false);
        spriteDark.gameObject.SetActive(true);
        cardMask.gameObject.SetActive(false);
        // button.interactable = false;
    }

    void Ready() {
        spriteLight.gameObject.SetActive(true);
        spriteDark.gameObject.SetActive(false);
        // button.interactable = true;
    }

}