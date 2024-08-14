using System;
using UnityEngine;



[CreateAssetMenu(fileName = "PlantTM", menuName = "TM/PlantTM")]

public class PlantTM : ScriptableObject {

    public int typeID;

    public float spawnBulletInterval;

    public int spawnBulletTimer;

    [Header("Sprites")]

    public Sprite sprite;

    public RuntimeAnimatorController animator;

}