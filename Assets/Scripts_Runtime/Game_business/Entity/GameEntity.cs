using System.Collections;
using UnityEngine;

public class GameEntity {
    public float restFixTime;

    // 手上是否有植物

    public PlantEntity handPlant; // null
    // public ulong handPlant; // 0

    public Vector2 textWorldPos;

    // 自动生成阳光

    public float sunSpawnInterval;

    public float sunSpawnTimer;

    public GameEntity() {
        handPlant = null;

        sunSpawnInterval = 5;
        sunSpawnTimer = 0;

    }

}