using UnityEngine;

public class GameContext {

    public GameEntity gameEntity;

    // repo

    public PlantRepository plantRepository;

    // inject
    public AssetsContext assetsContext;

    public IDService idService;

    public ModuleInput moduleInput;

    public Canvas canvas;   

    public Camera camera;

    public GameContext() {
        gameEntity = new GameEntity();

        plantRepository = new PlantRepository();
    }

    public void Inject(AssetsContext assetsContext, IDService idService,ModuleInput moduleInput,Canvas canvas,Camera camera) {
        this.assetsContext = assetsContext;
        this.idService = idService;
        this.moduleInput = moduleInput;
        this.canvas = canvas;
        this.camera = camera;
    }


}