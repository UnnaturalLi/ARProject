using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DefaultObserverEventHandler))]
public class DetectManager : MonoSingleton<DetectManager>
{
    private DefaultObserverEventHandler _handler;
    private void Awake()
    {
        base.Awake();
        _handler = GetComponent<DefaultObserverEventHandler>();
        _handler.OnTargetLost.AddListener(()=>Debug.Log("ModelIsLost"));
    }
    public void RegisterMethodOnFound(UnityAction action)
    {
        Debug.Log("Added");
        _handler.OnTargetFound.AddListener(action);
    }
    public void RegisterMethodOnLost(UnityAction action)
    {
        Debug.Log("LostAdded");
        _handler.OnTargetLost.AddListener(action);
    }
}
