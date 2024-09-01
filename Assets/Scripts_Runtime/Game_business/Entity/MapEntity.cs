using System;
using System.Collections;
using UnityEngine;


public class MapEntity : MonoBehaviour {

    [SerializeField] SpriteRenderer spriteRenderer;

    public int id;

    public int typeID;

    public void Ctor() { }

    public void SetSprite(Sprite sprite) {
        spriteRenderer.sprite = sprite;
    }



}