using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Panel_Point : MonoBehaviour {


    [SerializeField] Button ModifyName;

    public Action OnClickModifyNameHandle;
    public void Ctor() {
        ModifyName.onClick.AddListener(() => {
            OnClickModifyNameHandle?.Invoke();
        });
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void TearDown() {
        GameObject.Destroy(gameObject);
    }


}