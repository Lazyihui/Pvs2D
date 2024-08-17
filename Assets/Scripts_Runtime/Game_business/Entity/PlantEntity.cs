using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlantEntity : MonoBehaviour {

    [SerializeField] public Animator anim; // ulong

    [SerializeField] SpriteRenderer sprite; // ulong
    public int id;

    public int typeID;


    public PlantStatus status; // int

    // 
    public int hp;

    public int hpMax;


    // 时间什么的

    public float spawnBulletInterval;

    public float spawnBulletTimer;


    public void Ctor() {
        status = PlantStatus.Disable;
    }

    public void TakeDamage(int damage) {
       
    }

    public void TearDown() {
        Destroy(gameObject);
    }

    public void SetAnim(RuntimeAnimatorController animator, Sprite sprite) {
        anim.runtimeAnimatorController = animator;
        this.sprite.sprite = sprite;
    }

    public void SetPos(Vector2 pos) {
        transform.position = pos;
    }


    public void AnimSetTrigger() {
        anim.SetTrigger("IsGlowing");
    }


}