using System;
using UnityEngine;


public class Panel_Goods : MonoBehaviour {

    [SerializeField] Panel_GoodsElement goodsElementPrefab;

    [SerializeField] Transform goodsElementGruop;


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

    public void Show() {
        gameObject.SetActive(true);
    }

}