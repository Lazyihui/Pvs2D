using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleAudio : MonoBehaviour {

    [SerializeField] AudioSource audioSource;


    public void PlayAudio(string path) {
        AudioClip clip = Resources.Load<AudioClip>(path);
        Debug.Log(clip);
        audioSource.clip = clip;
        audioSource.Play();
    }


    public void PlayClipButton(string path, float voluem) {

        AudioClip clip = Resources.Load<AudioClip>(path);
        AudioSource.PlayClipAtPoint(clip, transform.position, voluem);
    }


}