using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Login : MonoBehaviour {

    [SerializeField] Button btnLogin;

    [SerializeField] Text txtLogin;


    public Action OnClickLoginHandle;

    public void Ctor() {
        btnLogin.onClick.AddListener(() => {
            OnClickLoginHandle.Invoke();
        });
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void TearDown() {
        Destroy(gameObject);
    }

}