using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    public GameObject UICanvas;
    [SerializeField] private Button disAssembleButton;
    [SerializeField] private Button changeButton;
    private bool isDisassembled = false;
    private void Start()
    {
        DetectManager.Instance.RegisterMethodOnFound(OnShowUI);
        DetectManager.Instance.RegisterMethodOnLost(OnHideUI);
        disAssembleButton.onClick.AddListener(OnDisassembleClicked);
        changeButton.onClick.AddListener(ChangeMaterial);
    }

    public void ChangeMaterial()
    {
        ModelManager.Instance.ChangeMaterial();
    }
    public void OnShowUI()
    {
        UICanvas.SetActive(true);
    }
    public void OnHideUI()
    {
        UICanvas.SetActive(false);
        OnDisableModel();
    }

    public void OnDisableModel()
    {
        if (isDisassembled)
        {
            isDisassembled = false;
            ModelManager.Instance.Assemble();
            disAssembleButton.GetComponentInChildren<Text>().text =
                "拆解";
        }
    }
    public void OnDisassembleClicked()
    {
        if (isDisassembled)
        {
            ModelManager.Instance.Assemble();
            disAssembleButton.GetComponentInChildren<Text>().text =
                "拆解";
        }
        else
        {
            ModelManager.Instance.DisAssemble();
            disAssembleButton.GetComponentInChildren<Text>().text =
                "组装";
        }
        isDisassembled = !isDisassembled;
    }
}
