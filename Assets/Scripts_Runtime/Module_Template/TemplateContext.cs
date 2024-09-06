using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;



public class TemplateContext {


    public Dictionary<int, CardTM> cards;


    public AsyncOperationHandle cardPtr;


    public Dictionary<int, PlantTM> plants;

    public AsyncOperationHandle plantPtr;

    public Dictionary<int, BulletTM> bullets;

    public AsyncOperationHandle bulletPtr;

    public Dictionary<int, AudioTM> audios;

    public AsyncOperationHandle audioPtr;

    public Dictionary<int, MapTM> maps;

    public AsyncOperationHandle mapPtr;

    public Dictionary<int, flagTM> flags;

    public AsyncOperationHandle flagPtr;

    public TemplateContext() {
        cards = new Dictionary<int, CardTM>();
        plants = new Dictionary<int, PlantTM>();
        bullets = new Dictionary<int, BulletTM>();
        audios = new Dictionary<int, AudioTM>();
        maps = new Dictionary<int, MapTM>();
        flags = new Dictionary<int, flagTM>();
    }
}