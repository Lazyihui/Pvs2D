using System;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class TemplateInfra {


    public static void Load(TemplateContext ctx) {

        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "CardTM";
            var ptr = Addressables.LoadAssetsAsync<CardTM>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.cards.Add(go.typeID, go);
            }
            ctx.cardPtr = ptr;


        }
        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "PlantTM";
            var ptr = Addressables.LoadAssetsAsync<PlantTM>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.plants.Add(go.typeID, go);
            }
            ctx.plantPtr = ptr;
        }
        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "BulletTM";
            var ptr = Addressables.LoadAssetsAsync<BulletTM>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.bullets.Add(go.typeID, go);
            }
            ctx.bulletPtr = ptr;
        }

        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "AudioTM";
            var ptr = Addressables.LoadAssetsAsync<AudioTM>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.audios.Add(go.typeID, go);
            }
            ctx.audioPtr = ptr;
        }
        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "MapTM";
            var ptr = Addressables.LoadAssetsAsync<MapTM>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.maps.Add(go.typeID, go);
            }
            ctx.mapPtr = ptr;
        }

        {
            AssetLabelReference labelReference = new AssetLabelReference();
            labelReference.labelString = "FlagTM";
            var ptr = Addressables.LoadAssetsAsync<flagTM>(labelReference, null);
            var list = ptr.WaitForCompletion();
            foreach (var go in list) {
                ctx.flags.Add(go.typeID, go);
            }
            ctx.flagPtr = ptr;
        }
    }


    public static void Unload(TemplateContext ctx) {
        if (ctx.cardPtr.IsValid()) {
            Addressables.Release(ctx.cardPtr);
        }
        if (ctx.plantPtr.IsValid()) {
            Addressables.Release(ctx.plantPtr);
        }
        if (ctx.bulletPtr.IsValid()) {
            Addressables.Release(ctx.bulletPtr);
        }
        if (ctx.audioPtr.IsValid()) {
            Addressables.Release(ctx.audioPtr);
        }
        if (ctx.mapPtr.IsValid()) {
            Addressables.Release(ctx.mapPtr);
        }
        if (ctx.flagPtr.IsValid()) {
            Addressables.Release(ctx.flagPtr);
        }
    }
}