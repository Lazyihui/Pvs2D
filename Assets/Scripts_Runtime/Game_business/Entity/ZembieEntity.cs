using System;
using System.Collections.Generic;
using UnityEngine;



public class ZembieEntity : MonoBehaviour {


    [SerializeField] Rigidbody2D rb;
    public int id;

    public int typeID;

    public int hp;

    public int hpMax;

    public bool isAttack;

    public Action<ZembieEntity, Collider2D> OntriggerEnter2DHandle;

    public Action<ZembieEntity, Collider2D> OntriggerExit2DHandle;
    public void Ctor() { }


    public void move() {
        //  var velo = rb.velocity;
        //     velo = dir * moveSpeed;
        //     rb.velocity = velo;
        var velo = rb.velocity;
        velo.x = Vector2.left.x * 0.2f;
        rb.velocity = velo;
    }


    void OntriggerEnter2D(Collider2D other) {

        Debug.Log("ZembieEntity OntriggerEnter2D");

        OntriggerEnter2DHandle?.Invoke(this, other);
    }
    void OntriggerExit2D(Collider2D other) {

        Debug.Log("ZembieEntity OntriggerExit2D");
        OntriggerExit2DHandle?.Invoke(this, other);
    }

}