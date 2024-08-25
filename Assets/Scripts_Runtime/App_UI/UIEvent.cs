using System;
using System.Collections;
using UnityEngine;



public class UIEvent {
    public Action<int> panel_GoodsElement_CardHandle;

    public void Panel_GoodsElement_CardClick(int id) {
        if (panel_GoodsElement_CardHandle != null) {
            panel_GoodsElement_CardHandle.Invoke(id);
        }
    }

    public Action panel_Login_LoginHandle;

    public void Panel_Login_LoginClick() {
        if (panel_Login_LoginHandle != null) {
            panel_Login_LoginHandle.Invoke();
        }
    }

    public Action panel_PointModifyNameHandle;

    public void Panel_PointModifyNameClick() {
        if (panel_PointModifyNameHandle != null) {
            panel_PointModifyNameHandle.Invoke();
        }
    }
}