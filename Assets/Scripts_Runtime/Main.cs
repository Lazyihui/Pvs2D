using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    MainContext ctx ;
    bool isTearDown = false;

    void Awake() {
        ctx = new MainContext();
    
    }

    // Update is called once per frame
    void Update() {
        float dt = Time.deltaTime;

    }

    void OnDestory() {
        TearDown();
    }

    void OnApplicationQuit() {
        TearDown();
    }

    void TearDown() {
        if (isTearDown) {
            return;
        }
        isTearDown = true;
        // === Unload===
        ModuleAssets.Unload(ctx.assetsContext);
    }
}
