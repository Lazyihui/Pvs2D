using UnityEngine;

public class GameContext {

    public GameEntity gameEntity;

    // repo

    public PlantRepository plantRepository;

    public CellRepository cellRepository;

    public BulletRepository bulletRepository;


    public ZembieRepository zembieRepository;
    // inject
    public AssetsContext assetsContext;

    public IDService idService;

    public ModuleInput moduleInput;

    public Canvas canvas;

    public Camera camera;

    public Transform CellGroup;

    public UIContext uiContext;

    public TemplateContext templateContext;
    public GameContext() {
        gameEntity = new GameEntity();

        plantRepository = new PlantRepository();
        cellRepository = new CellRepository();
        bulletRepository = new BulletRepository();
        zembieRepository = new ZembieRepository();
    }

    public void Inject(AssetsContext assetsContext, IDService idService, ModuleInput moduleInput, Canvas canvas,
    Camera camera, Transform CellGroup, UIContext uiContext,TemplateContext templateContext) {
        this.assetsContext = assetsContext;
        this.idService = idService;
        this.moduleInput = moduleInput;
        this.canvas = canvas;
        this.camera = camera;
        this.CellGroup = CellGroup;
        this.uiContext = uiContext;
        this.templateContext = templateContext;
    }


}