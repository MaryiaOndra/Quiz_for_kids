using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPanel : MonoBehaviour
{
    public Action RestartAction;

    public void Activate() 
    {
        gameObject.SetActive(true);
    }

    public void Diactivate() 
    {
        gameObject.SetActive(false);
        RestartAction.Invoke();
    }
}
