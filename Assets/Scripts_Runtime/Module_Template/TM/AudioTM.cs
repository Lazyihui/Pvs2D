using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "AudioTM", menuName = "TM/AudioTM")]

public class AudioTM : ScriptableObject {
    public AudioClip clip;


    public int typeID;
}