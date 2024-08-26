using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Panel_ModifyName : MonoBehaviour {
    [SerializeField] TMP_InputField inputField;
    [SerializeField] Button btnConfirm;

    public Action OnbtnConfirmHandle;
    public void Ctor() {
        btnConfirm.onClick.AddListener(() => {
            OnbtnConfirmHandle?.Invoke();
        });
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void TearDown() {
        GameObject.Destroy(gameObject);
    }


}