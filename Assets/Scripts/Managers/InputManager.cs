using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    public float pinchValue;
    public float slideValue;
    private Touch _touch0;
    private Touch _touch1;
    private void Update()
    {
        if (Input.touchCount == 1)
        {
            _touch0 = Input.GetTouch(0);
            slideValue = _touch0.deltaPosition.x;
        }
        else
        {
            slideValue = 0;
        }

        if (Input.touchCount == 2)
        {
            _touch0 = Input.GetTouch(0);
            _touch1 = Input.GetTouch(1);
            Vector2 touch0Pre =
                _touch0.position - _touch0.deltaPosition;
            Vector2 touch1Pre =
                _touch1.position - _touch1.deltaPosition;
            pinchValue = Vector2.Distance(touch0Pre, touch1Pre) -
                         Vector2.Distance(_touch0.position,
                             _touch1.position);
        }
        else
        {
            pinchValue = 0;
        }
    }
}
