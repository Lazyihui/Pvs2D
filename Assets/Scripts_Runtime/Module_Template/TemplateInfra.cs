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

    }


    public static void Unload(TemplateContext ctx) {
        if (ctx.cardPtr.IsValid()) {
            Addressables.Release(ctx.cardPtr);
        }
        if (ctx.plantPtr.IsValid()) {
            Addressables.Release(ctx.plantPtr);
        }

    }
}