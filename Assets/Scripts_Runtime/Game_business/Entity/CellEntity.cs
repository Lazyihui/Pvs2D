using System;
using UnityEngine;
using UnityEngine.UI;


public class CellEntity : MonoBehaviour {


    public int id;

    public Vector2Int pos;

    public Action OnMouseDownHandle;

    public bool isHavsPlant;

    public void Ctor() { 
        isHavsPlant = false;
    }


    public void SetPosInt(Vector2Int pos) {
        this.pos = pos;
    }

    public void OnMouseDown() {
        OnMouseDownHandle.Invoke();
    }
}