using System;
using UnityEngine;



[CreateAssetMenu(fileName = "PlantTM", menuName = "TM/PlantTM")]

public class PlantTM : ScriptableObject {

    public int typeID;

    [Header("Timer")]
    public float spawnBulletInterval;

    public int spawnBulletTimer;


    [Header("HP")]

    public int hp;

    public int hpMax;

    [Header("Sprites")]

    public Sprite sprite;

    public RuntimeAnimatorController animator;

}