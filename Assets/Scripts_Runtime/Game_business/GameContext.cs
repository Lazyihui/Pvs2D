using UnityEngine;

public class GameContext {

    public GameEntity gameEntity;

    // repo

    public PlantRepository plantRepository;

    public CellRepository cellRepository;

    public BulletRepository bulletRepository;


    public ZembieRepository zembieRepository;

    public ZembieHeadRepository zembieHeadRepository;

    public AudioRepository audioRepository;
    public MapRepository mapRepository;

    // inject
    public AssetsContext assetsContext;

    public IDService idService;

    public ModuleInput moduleInput;

    public Canvas canvas;


    public Transform CellGroup;

    public UIContext uiContext;

    public TemplateContext templateContext;

    public ModuleCamera moduleCamera;
    public GameContext() {
        gameEntity = new GameEntity();

        plantRepository = new PlantRepository();
        cellRepository = new CellRepository();
        bulletRepository = new BulletRepository();
        zembieRepository = new ZembieRepository();
        zembieHeadRepository = new ZembieHeadRepository();
        audioRepository = new AudioRepository();
        mapRepository = new MapRepository();
    }

    public void Inject(AssetsContext assetsContext, IDService idService, ModuleInput moduleInput, Canvas canvas,
   Transform CellGroup, UIContext uiContext, TemplateContext templateContext, ModuleCamera moduleCamera) {
        this.assetsContext = assetsContext;
        this.idService = idService;
        this.moduleInput = moduleInput;
        this.canvas = canvas;
        this.CellGroup = CellGroup;
        this.uiContext = uiContext;
        this.templateContext = templateContext;
        this.moduleCamera = moduleCamera;
    }


}