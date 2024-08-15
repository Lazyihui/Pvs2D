using System;
using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(fileName = "BulletTM", menuName = "TM/BulletTM")]

public class BulletTM : ScriptableObject {

    public int typeID;


    [Header("Sprites")]
    public Sprite sprite;

    public RuntimeAnimatorController animator;




}