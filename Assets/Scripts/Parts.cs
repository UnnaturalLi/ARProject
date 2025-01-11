using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour
{
    public Vector3 initPosition;
    public Vector3 disassemblePosition;
    private Vector3 _currentPosition;
    private Vector3 _targetPosition;
    private Vector3 _cache;
    void Start()
    {
        initPosition = transform.localPosition;
        ModelManager.Instance.OnAssemble += (() =>
        {
           _targetPosition = initPosition;
        });
        ModelManager.Instance.OnDisassemble += (() =>
        {
            _targetPosition = disassemblePosition;
        });
    }

    private void Update()
    {
        _currentPosition = transform.localPosition;
        if (Mathf.Abs(Vector3.Distance(_targetPosition,
                _currentPosition)) > 0.01f)
        {
            transform.localPosition=Vector3.SmoothDamp(_currentPosition, _targetPosition,
                ref _cache, 0.1f);
        }
    }
}
