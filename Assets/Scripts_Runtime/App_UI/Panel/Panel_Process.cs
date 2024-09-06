using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Process : MonoBehaviour {

    public float width;

    [SerializeField] Transform elementGroup;


    public void Ctor() {

        width = 321;

    }


    public void Addflag(UIContext ctx, int typeID,Vector2 pos) {

        bool has = ctx.templateContext.flags.TryGetValue(typeID, out flagTM tm);
        if (!has) {
            Debug.LogError("flagTM not found");
            return;
        }

        ctx.assetsContext.TryGetPanel("Panel_ProcessFlag", out GameObject prefab);
        Panel_ProcessFlag element = GameObject.Instantiate(prefab, elementGroup).GetComponent<Panel_ProcessFlag>();

        element.Ctor();
        element.SetPos(pos);

        element.SetWidth(width);
        element.SetImage(tm.sprite);
        element.Show();

        element.id++;
        element.typeID = typeID;
        ctx.flagRespository.Add(element);
    }

    public void Show() {
        this.gameObject.SetActive(true);
    }

    public void TearDown() {
        GameObject.Destroy(this.gameObject);
    }



}