using System;
using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(fileName = "BulletTM", menuName = "TM/BulletTM")]

public class BulletTM : ScriptableObject {

    public int typeID;

    public float atkValue;

    public float moveSpeed;

    [Header("Sprites")]
    public Sprite sprite;

    public RuntimeAnimatorController animator;




}