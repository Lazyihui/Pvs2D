using System.Collections;
using UnityEngine;

public class GameEntity {
    public float restFixTime;

    // 手上是否有植物

    public PlantEntity handPlant; // null
    // public ulong handPlant; // 0

    public Vector2 textWorldPos;

    public GameEntity() {
        handPlant = null;
    }

}