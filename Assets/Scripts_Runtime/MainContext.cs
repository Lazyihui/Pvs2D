using UnityEngine;

public class MainContext {

    public Transform CellGroup;


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


    public void Inject(Canvas canvas, Camera camera, Transform CellGroup) {
        this.canvas = canvas;
        this.camera = camera;
        this.CellGroup = CellGroup;
        uiContext.Inject(assetsContext, canvas, idService);
        gameContext.Inject(assetsContext, idService, moduleInput, canvas, camera, CellGroup,uiContext);
    }
}