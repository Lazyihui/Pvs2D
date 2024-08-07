using System.Collections;
using UnityEngine;

public class UIContext {

    public UIEvent uiEvent;

    // panel
    public Panel_Goods panel_Goods;

    // repo
    public GoodsRespository goodsRespository;

    // inject
    public AssetsContext assetsContext;

    public IDService idService;
    public Canvas canvas;
    public UIContext() {
        goodsRespository = new GoodsRespository();
        uiEvent = new UIEvent();
    }

    public void Inject(AssetsContext assetsContext, Canvas canvas, IDService idService) {
        this.assetsContext = assetsContext;
        this.canvas = canvas;
        this.idService = idService;
    }

}