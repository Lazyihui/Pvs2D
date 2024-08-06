using System;
using UnityEngine;


public class Panel_Goods : MonoBehaviour {

    [SerializeField] Panel_GoodsElment goodsElementPrefab;

    [SerializeField] Transform goodsElementGruop;


    public void Ctor() { }


    public void AddGoodsElement() {
        Panel_GoodsElment goodsElement = Instantiate(goodsElementPrefab, goodsElementGruop);

        // goodsElement.Init(spriteLight, spriteDark);
        goodsElement.Ctor();

        // TODO:
        goodsElement.OnClickCardHandle = () => {
            Debug.Log("Click ");
        };

    }

    public void Show() {
        gameObject.SetActive(true);
    }

}