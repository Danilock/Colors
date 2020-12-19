using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Paused,
        InGame,
        Loading
    }

    public GameState currentGameState;
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
}
