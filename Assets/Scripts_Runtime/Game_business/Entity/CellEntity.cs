using System;
using UnityEngine;
using UnityEngine.UI;


public class CellEntity : MonoBehaviour {


    public int id;

    public Vector2Int pos;

    public void Ctor() { }


    public void SetPosInt(Vector2Int pos) {
        this.pos = pos;
    }


}