using System;
using System.Collections.Generic;
using UnityEngine;



public class ZembieEntity : MonoBehaviour {


    [SerializeField] public Animator anim;

    // [SerializeField] public Animation attackAnim;

    [SerializeField] Rigidbody2D rb;

    [SerializeField] SpriteRenderer sprite;

    public bool haveHead;
    public ZembieStatus status;
    public int id;

    public int typeID;

    public float hp;

    public float hpMax;


    public int atkValue;

    public float atkDuration;

    public float atkTimer;

    public PlantEntity targetPlant;  //只用于记录攻击的植物

    public Action<ZembieEntity, Collision2D> OnCollisionEnter2DHandle;

    public Action<ZembieEntity, Collision2D> OnCollisionExit2DHandle;
    public void Ctor() { }

    public void SetAnim(int speed) {
        anim.speed = speed;
    }

    public void SetSpriteLayer(int layer) {
        sprite.sortingOrder = layer;
    }


    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }

    public void move() {
        var velo = rb.velocity;
        velo.x = Vector2.left.x * 0.2f;
        rb.velocity = velo;
    }

    public void ClearVelocity() {
        rb.velocity = Vector2.zero;
    }


    public void TearDown() {
        Destroy(gameObject, 1);
    }


    void OnCollisionEnter2D(Collision2D other) {
        OnCollisionEnter2DHandle.Invoke(this, other);
    }

    void OnCollisionExit2D(Collision2D other) {
        OnCollisionExit2DHandle.Invoke(this, other);
    }


}