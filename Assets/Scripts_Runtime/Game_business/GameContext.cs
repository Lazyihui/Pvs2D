using UnityEngine;

public class GameContext {

    public GameEntity gameEntity;

    // repo

    public PlantRepository plantRepository;

    public CellRepository cellRepository;
    // inject
    public AssetsContext assetsContext;

    public IDService idService;

    public ModuleInput moduleInput;

    public Canvas canvas;   

    public Camera camera;

    public Transform CellGroup;

    public UIContext uiContext;
    public GameContext() {
        gameEntity = new GameEntity();

        plantRepository = new PlantRepository();
        cellRepository = new CellRepository();
    }

    public void Inject(AssetsContext assetsContext, IDService idService,ModuleInput moduleInput,Canvas canvas,Camera camera,Transform CellGroup,UIContext uiContext) {
        this.assetsContext = assetsContext;
        this.idService = idService;
        this.moduleInput = moduleInput;
        this.canvas = canvas;
        this.camera = camera;
        this.CellGroup = CellGroup;
        this.uiContext = uiContext;
    }


}