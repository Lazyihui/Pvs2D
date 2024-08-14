using System;
using UnityEngine;
using UnityEngine.UI;



[CreateAssetMenu(fileName = "CardTM", menuName = "TM/CardTM")]

public class CardTM : ScriptableObject {

    public int typeID;


    public int planetCount;

    public int needSunCount;

    [Header("Sprites")]
    public Sprite spriteLight;

    

}