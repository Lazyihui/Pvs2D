using System;
using UnityEngine;
using UnityEngine.UI;


public class Panel_GoodsElment : MonoBehaviour
{
    [SerializeField] Button button;

    [SerializeField] Image spriteLight;

    [SerializeField] Image spriteDark;

    public GoodStatus status;

    public Action OnClickCardHandle;

    public void Ctor() { 
        status = GoodStatus.Cooling;
    }

    // public void SetStatus(GoodStatus status)
    // {
    //     this.status = status;
    //     switch (status)
    //     {
    //         case GoodStatus.Cooling:
    //             button.image.sprite = spriteDark;
    //             break;
    //         case GoodStatus.WaitingSun:
    //             button.image.sprite = spriteDark;
    //             break;
    //         case GoodStatus.Ready:
    //             button.image.sprite = spriteLight;
    //             break;
    //         case GoodStatus.Done:
    //             button.image.sprite = spriteLight;
    //             break;
    //         default:
    //             break;
    //     }
    // }



}