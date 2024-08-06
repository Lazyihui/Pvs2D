using System.Collections;
using UnityEngine;

public class UIContext {
    // panel
    public Panel_Goods panel_Goods;

    // inject
    public AssetsContext assetsContext;

    public Canvas canvas;
    public UIContext() {
    }

    public void Inject(AssetsContext assetsContext, Canvas canvas) {
        this.assetsContext = assetsContext;
        this.canvas = canvas;
    }

}