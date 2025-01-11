using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T :MonoSingleton<T>
{
    public static T Instance;
    protected virtual void Awake()
    {
        
            Instance = (T)this;
        
         //else{Destroy(this.gameObject);}
    }
}
