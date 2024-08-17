using System;
using System.Collections.Generic;
using UnityEngine;



public class ZembieEntity : MonoBehaviour {


    [SerializeField] public Animator anim;

    [SerializeField] Rigidbody2D rb;
    public int id;

    public int typeID;

    public int hp;

    public int hpMax;

    public bool isAttack;

    public Action<ZembieEntity, Collision2D> OnCollisionEnter2DHandle;

    public Action<ZembieEntity, Collision2D> OnCollisionExit2DHandle;
    public void Ctor() { }


    public void move() {
        //  var velo = rb.velocity;
        //     velo = dir * moveSpeed;
        //     rb.velocity = velo;
        var velo = rb.velocity;
        velo.x = Vector2.left.x * 0.2f;
        rb.velocity = velo;
    }

    void OnCollisionEnter2D(Collision2D other) {
        OnCollisionEnter2DHandle.Invoke(this, other);
    }

    void OnCollisionExit2D(Collision2D other) {
        OnCollisionExit2DHandle.Invoke(this, other);
    }


}