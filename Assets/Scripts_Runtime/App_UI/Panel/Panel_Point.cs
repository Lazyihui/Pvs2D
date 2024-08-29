using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Panel_Point : MonoBehaviour {

    [SerializeField] Text Name;

    [SerializeField] Button ModifyName;

    [SerializeField] Button btn_Advance;
    [SerializeField] Button btn_MiniGame;
    [SerializeField] Button btn_Brain;


    public Action OnClickModifyNameHandle;


    public Action OnClickAdvanceHandle;

    public Action OnClickMiniGameHandle;

    public Action OnClickBrainHandle;
    public void Ctor() {
        ModifyName.onClick.AddListener(() => {
            OnClickModifyNameHandle?.Invoke();
        });

        btn_Advance.onClick.AddListener(() => {
            OnClickAdvanceHandle?.Invoke();
        });

        btn_MiniGame.onClick.AddListener(() => {
            OnClickMiniGameHandle?.Invoke();
        });

        btn_Brain.onClick.AddListener(() => {
            OnClickBrainHandle?.Invoke();
        });


    }

    public void SetName(string name) {
        Name.text = name;
    }


    public void Show() {
        gameObject.SetActive(true);
    }

    public void TearDown() {
        GameObject.Destroy(gameObject);
    }


}