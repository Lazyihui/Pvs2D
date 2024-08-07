using System;
using UnityEngine;
using UnityEngine.UI;


public class Panel_GoodsElement : MonoBehaviour {
    [SerializeField] Button cardButton;

    [SerializeField] Image spriteLight;

    [SerializeField] Image spriteDark;

    [SerializeField] Image cardMask;

    public int id;

    public int typeID;
    public GoodStatus status;


    public Action<int, int> OnClickCardHandle;

    public float cdTime;

    public float cdTimer;

    // 每个卡片要的阳光数量
    public int plantCount;

    public void Init(Sprite spriteLight, Sprite spriteDark, int planetCount) {
        this.spriteLight.sprite = spriteLight;
        this.spriteDark.sprite = spriteDark;
        this.plantCount = planetCount;
    }

    public void Ctor() {
        status = GoodStatus.Cooling;

        cardButton.onClick.AddListener(() => {
            OnClickCardHandle(this.typeID, this.plantCount);
        });

        // 不能写在这里 要用TM
        cdTime = 2;
        cdTimer = 0;

        plantCount = 50;
    }

    //这里逻辑有点问题
    public void SetStatus(GoodStatus status, int sunCount, float dt) {
        this.status = status;
        if (status == GoodStatus.Cooling) {
            Cooling(dt, sunCount);
        } else if (status == GoodStatus.WaitingSun) {
            WaitingSun(sunCount);
        } else if (status == GoodStatus.Ready) {
            Ready(sunCount);
        }

    }

    void Cooling(float dt, int sunCount) {
        // 冷却
        cdTimer += dt;
        cardMask.fillAmount = (cdTime - cdTimer) / cdTime;

        if (cdTimer >= cdTime) {
            this.status = GoodStatus.WaitingSun;
        }



        spriteLight.gameObject.SetActive(false);
        spriteDark.gameObject.SetActive(true);


    }

    void WaitingSun(int sunCount) {

        if (sunCount >= plantCount) {

            this.status = GoodStatus.Ready;
        } else {

            spriteLight.gameObject.SetActive(false);
            spriteDark.gameObject.SetActive(true);
            cardMask.gameObject.SetActive(false);

        }


    }

    void Ready(int sunCount) {

        spriteLight.gameObject.SetActive(true);
        spriteDark.gameObject.SetActive(false);
        cardMask.gameObject.SetActive(false);

        if (sunCount >= plantCount) {

        } else {
            status = GoodStatus.WaitingSun;
        }
    }



}