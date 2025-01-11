using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ModelManager : MonoSingleton<ModelManager>
{
    public Transform model;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _scaleSpeed;
    private bool _interactable;
    private Vector3 _scale;
    public Action OnDisassemble;
    public Action OnAssemble;
    public GameObject[] ExteriorSkin;
    private void Start()
    {
        DetectManager.Instance.RegisterMethodOnFound(OnEnableModel);
        DetectManager.Instance.RegisterMethodOnLost(OnDisableModel);
    }

    private void Update()
    {
        if (_interactable == true)
        {
            model.Rotate(model.up,
                -InputManager.Instance.slideValue * _rotateSpeed*Time.deltaTime,
                Space.World);
            _scale = model.localScale;
            float scaleChange =
                _scaleSpeed * InputManager.Instance.pinchValue*Time.deltaTime;
            float changedScale = model.localScale.x - scaleChange;
            changedScale = Mathf.Clamp(changedScale, 0.05f, 0.25f);
            model.localScale = new Vector3(changedScale, changedScale,
                changedScale);
        }
    }

    public void ChangeMaterial()
    {
        Color co = new Color(
            Random.Range(0f, 1f), 
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );
        foreach (var VARIABLE in ExteriorSkin)
        {
            VARIABLE.GetComponent<Renderer>().material.color = co;
        }
        
    }
    public void Assemble()
    {
        OnAssemble.Invoke();
    }
    public void DisAssemble()
    {
        OnDisassemble.Invoke();
    }
    public void OnEnableModel()
    {
        model.gameObject.SetActive(true);
        _interactable = true;
    }
    public void OnDisableModel()
    {
        model.gameObject.SetActive(false);
        _interactable = false;
    }
}
