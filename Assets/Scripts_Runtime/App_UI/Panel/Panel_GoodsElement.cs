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

    public CardType cardType;


    public Action<int> OnClickCardHandle;

    public float cdInterval;

    public float cdTimer;

    // 每个卡片要的阳光数量
    public int needSunCount;

    public void Init(Sprite spriteLight, Sprite spriteDark, int planetCount) {
        this.spriteLight.sprite = spriteLight;
        this.spriteDark.sprite = spriteDark;
        this.needSunCount = planetCount;
    }

    public void Ctor() {


        cardButton.onClick.AddListener(() => {
            // status = GoodStatus.Cooling;
            OnClickCardHandle(this.id);
        });

        // 不能写在这里 要用TM

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

    public void SetCardStatus(GoodStatus status) {
        this.status = status;
    }

    void Cooling(float dt, int sunCount) {
        // 冷却

        if (this.cardType == CardType.SelectCard) {

            spriteLight.gameObject.SetActive(false);
            spriteDark.gameObject.SetActive(true);
            cardMask.gameObject.SetActive(true);
        } else {
            cdTimer += dt;
            cardMask.fillAmount = (cdInterval - cdTimer) / cdInterval;

            if (cdTimer >= cdInterval) {
                this.status = GoodStatus.WaitingSun;
                cdTimer = 0;
            }
            spriteLight.gameObject.SetActive(false);
            spriteDark.gameObject.SetActive(true);
            cardMask.gameObject.SetActive(true);

        }
    }

    void WaitingSun(int sunCount) {

        if (sunCount >= needSunCount) {
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

        if (sunCount >= needSunCount) {
        } else {
            status = GoodStatus.WaitingSun;
        }
    }



}