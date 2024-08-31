using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEntity : MonoBehaviour {

    [SerializeField] AudioSource audioSource;

    public int id;

    public void Ctor() {
    }


    public void SetClip(AudioClip clip) {
        Debug.Log(clip);
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }



    public void TearDown() {
        GameObject.Destroy(gameObject);
    }


}