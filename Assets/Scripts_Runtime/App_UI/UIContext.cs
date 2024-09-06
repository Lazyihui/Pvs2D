using System.Collections;
using UnityEngine;

public class UIContext {

    public UIEvent uiEvent;

    // panel
    public Panel_Goods panel_Goods;

    public Panel_Prepare panel_Prepare;

    public Panel_Over panel_Over;

    public Panel_Login panel_Login;

    public Panel_Point panel_Point;

    public Panel_ModifyName panel_ModifyName;

    public Panel_SelectCard panel_SelectCard;

    public Panel_Process panel_Process;

    // repo
    public GoodsRespository goodsRespository;

    public FlagRespository flagRespository;

    // inject
    public AssetsContext assetsContext;

    public TemplateContext templateContext;

    public IDService idService;
    public Canvas canvas;
    public UIContext() {
        goodsRespository = new GoodsRespository();
        flagRespository = new FlagRespository();
        uiEvent = new UIEvent();
    }

    public void Inject(AssetsContext assetsContext, Canvas canvas, IDService idService,TemplateContext templateContext) {
        this.assetsContext = assetsContext;
        this.canvas = canvas;
        this.idService = idService;
        this.templateContext = templateContext;
    }

}