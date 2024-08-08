

public class GameContext {

    public GameEntity gameEntity;

    // repo

    public PlantRepository plantRepository;

    // inject
    public AssetsContext assetsContext;

    public IDService idService;


    public GameContext() {
        gameEntity = new GameEntity();

        plantRepository = new PlantRepository();
    }

    public void Inject(AssetsContext assetsContext, IDService idService) {
        this.assetsContext = assetsContext;
        this.idService = idService;
    }


}