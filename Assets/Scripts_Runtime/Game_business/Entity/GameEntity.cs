public class GameEntity {
    public float restFixTime;

    // 手上是否有植物
    public bool hasHandPlant;

    public PlantEntity handPlant;

    public GameEntity() {
        hasHandPlant = false;
        handPlant = null;
    }

}