using UnityEngine;

public class MainContext {
    public AssetsContext assetsContext;

    public UIContext uiContext;

    public GameContext gameContext;


    public IDService idService;
    public MainContext() {
        assetsContext = new AssetsContext();
        uiContext = new UIContext();
        idService = new IDService();
        gameContext = new GameContext();
    }


    public void Inject(Canvas canvas) {
        uiContext.Inject(assetsContext, canvas, idService);
        gameContext.Inject(assetsContext, idService);
    }
}