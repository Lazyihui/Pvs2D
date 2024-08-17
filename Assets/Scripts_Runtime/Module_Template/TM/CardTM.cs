using System;
using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(fileName = "CardTM", menuName = "TM/CardTM")]

public class CardTM : ScriptableObject {

    public int typeID;

    public float cdInterval;

    public int needSunCount;

    [Header("Sprites")]
    public Sprite spriteLight;

    public Sprite spriteDark;

    

}