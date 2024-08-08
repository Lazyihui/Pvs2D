using UnityEngine;

public class MainContext {
    public AssetsContext assetsContext;

    public UIContext uiContext;

    public GameContext gameContext;

    public ModuleInput moduleInput;


    public IDService idService;

    public Canvas canvas;

    public Camera camera;
    public MainContext() {
        assetsContext = new AssetsContext();
        uiContext = new UIContext();
        idService = new IDService();
        gameContext = new GameContext();
        moduleInput = new ModuleInput();
    }


    public void Inject(Canvas canvas,Camera camera) {
        this.canvas = canvas;
        this.camera = camera;
        uiContext.Inject(assetsContext, canvas, idService);
        gameContext.Inject(assetsContext, idService,moduleInput,canvas,camera);
    }
}