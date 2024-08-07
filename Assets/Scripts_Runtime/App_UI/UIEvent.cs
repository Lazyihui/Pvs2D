using System;
using System.Collections;
using UnityEngine;



public class UIEvent {
    public Action<int, int> panel_GoodsElement_CardHandle;

    public void Panel_GoodsElement_CardClick(int typeID, int plantCount) {
        if (panel_GoodsElement_CardHandle != null) {
            panel_GoodsElement_CardHandle.Invoke(typeID, plantCount);
        }
    }
}