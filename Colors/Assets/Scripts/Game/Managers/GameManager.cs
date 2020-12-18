using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
                Debug.LogError("Manager is Null");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void DebugName()
    {
        Debug.Log("Hey I'm the GameManager");
    }
}
