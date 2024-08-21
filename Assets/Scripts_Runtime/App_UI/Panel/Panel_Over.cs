using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Over : MonoBehaviour {


    public void Ctor() { }



    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

    public void TearDown() {
        Destroy(gameObject);
    }
}