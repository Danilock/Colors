﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsChecker : MonoBehaviour
{
    [SerializeField] Button[] _LevelButtons;
    // Start is called before the first frame update
    void Start()
    {
        InitializeLevelButtons();
    }

    void InitializeLevelButtons()
    {
        for(int i = 0; i < GameManager.Instance.LastLevel; i++)
        {
            _LevelButtons[i].interactable = true;
        }
    }
}
