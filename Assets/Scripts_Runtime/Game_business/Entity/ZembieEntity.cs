using System;
using System.Collections.Generic;
using UnityEngine;



public class ZembieEntity : MonoBehaviour {


    [SerializeField] Rigidbody2D rb;
    public int id;

    public int typeID;

    public int hp;

    public int hpMax;

    public void Ctor() { }


    public void move() {
        //  var velo = rb.velocity;
        //     velo = dir * moveSpeed;
        //     rb.velocity = velo;


        var velo = rb.velocity;
        velo.x = Vector2.left.x * 2;
        rb.velocity = velo;
    }
}