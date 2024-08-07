using System;
using UnityEngine;


public class Panel_Goods : MonoBehaviour {

    [SerializeField] Panel_GoodsElement goodsElementPrefab;

    [SerializeField] Transform goodsElementGruop;


    public void Ctor() { }


    public void AddGoodsElement(UIContext ctx) {
        Panel_GoodsElement goodsElement = Instantiate(goodsElementPrefab, goodsElementGruop);

        // goodsElement.Init(spriteLight, spriteDark);
        goodsElement.Ctor();

        goodsElement.id = ctx.idService.goodsIDRecord++;
        ctx.goodsRespository.Add(goodsElement);

        // TODO:
        goodsElement.OnClickCardHandle = () => {
            Debug.Log("Click ");
        };

    }

    public void Show() {
        gameObject.SetActive(true);
    }

}