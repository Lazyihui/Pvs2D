using System;
using UnityEngine;
using UnityEngine.UI;

public class Panel_ModifyName : MonoBehaviour {
    
    [SerializeField] InputField inputField;

    [SerializeField] Button btnConfirm;

    [SerializeField] Button btnCancel;

    public Action<string> OnbtnConfirmHandle;



    public Action OnbtnCancelHandle;
    public void Ctor() {
        btnConfirm.onClick.AddListener(() => {
            OnbtnConfirmHandle?.Invoke(inputField.text);
        });

        btnCancel.onClick.AddListener(() => {
            OnbtnCancelHandle?.Invoke();
        });
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void TearDown() {
        GameObject.Destroy(gameObject);
    }


}