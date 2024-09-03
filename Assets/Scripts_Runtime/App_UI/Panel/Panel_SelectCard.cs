using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Panel_SelectCard : MonoBehaviour {

    [SerializeField] Panel_GoodsElement cardElementPrefab;

    [SerializeField] Transform cardElementGroup;
    public void Ctor() { }


    public void AddCardElement(UIContext ctx, int typeID) {

        bool has = ctx.templateContext.cards.TryGetValue(typeID, out CardTM tm);

        if(!has){
            Debug.LogError("no card typeID: " + typeID);
            return;
        }

        Panel_GoodsElement ele = Instantiate(cardElementPrefab, cardElementGroup);

        ele.cardType = CardType.SelectCard;
        ele.Ctor();
        ele.typeID = typeID;
        ele.Init(tm.spriteLight, tm.spriteDark, tm.needSunCount);
        ele.OnClickCardHandle = (id) => {
            ctx.uiEvent.Panel_GoodsElement_CardClick(id);
        };

        ele.cdTimer = 0;

        ele.cdInterval = tm.cdInterval;
        ele.needSunCount = tm.needSunCount;

        ele.id = ctx.idService.goodsIDRecord++;
        ctx.goodsRespository.Add(ele);

        


    }
    public void Show() {
        gameObject.SetActive(true);
    }
    public void TearDown() {
        Destroy(gameObject);
    }
}