using System.Collections;
using UnityEngine;

public class GameEntity {
    public float restFixTime;


    public GameStatus gameStatus;
    // 手上是否有植物

    public PlantEntity handPlant; // null
    // public ulong handPlant; // 0

    public Vector2 textWorldPos;

    // 自动生成阳光

    public float sunSpawnInterval;

    public float sunSpawnTimer;

    public Vector2[] zembieSpawnPos;

    public float zembieSpawnTimer;

    public bool isGameBegin;

    // 记录植物卡片的数量
    public int plantCardCount;

    // 一局游戏的时间
    public float gameTotallTime;

    public GameEntity() {

        // 应该是GameStatus.Login 我还没写
        gameStatus = GameStatus.Loading;

        handPlant = null;

        sunSpawnInterval = 5;
        sunSpawnTimer = 0;

        zembieSpawnTimer = 0;

        zembieSpawnPos = new Vector2[5];
        zembieSpawnPos[0] = new Vector2(9, 3.32f);
        zembieSpawnPos[1] = new Vector2(9, 1.73f);
        zembieSpawnPos[2] = new Vector2(9, -0.05f);
        zembieSpawnPos[3] = new Vector2(9, -1.47f);
        zembieSpawnPos[4] = new Vector2(9, -3.28f);

        isGameBegin = false;

        plantCardCount = 0;

        gameTotallTime = 60;

    }

}