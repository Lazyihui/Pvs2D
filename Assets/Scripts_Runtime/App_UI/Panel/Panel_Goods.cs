using System;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Goods : MonoBehaviour {

    [SerializeField] Panel_GoodsElement goodsElementPrefab;

    [SerializeField] Transform goodsElementGruop;
    [SerializeField] Text sunCountText;


    public void Ctor() { }


    public void AddGoodsElement(UIContext ctx) {
        Panel_GoodsElement ele = Instantiate(goodsElementPrefab, goodsElementGruop);

        // goodsElement.Init(spriteLight, spriteDark);
        ele.Ctor();

        ele.OnClickCardHandle = (typeID, plantCount) => {
            ctx.uiEvent.Panel_GoodsElement_CardClick(typeID, plantCount);
        };




        ele.id = ctx.idService.goodsIDRecord++;
        ctx.goodsRespository.Add(ele);


    }

    public void SetSunCount(int sunCount) {
        sunCountText.text = sunCount.ToString();
    }


    public void Show() {
        gameObject.SetActive(true);
    }

}