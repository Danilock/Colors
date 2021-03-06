﻿using System;
using System.Collections;
using System.Collections.Generic;
using Game.Sound;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Game.Level_Complete_System
{
    [RequireComponent(typeof(LevelLoader))]
    public class DoorsManager : MonoBehaviour
    {
        #region DoorsManager Events
        public delegate void OnLevelStartTrigger();
        public event OnLevelStartTrigger OnLevelStart;

        public delegate void OnLevelCompleteTrigger();
        public event OnLevelCompleteTrigger OnLevelComplete;
        #endregion

        [SerializeField] private List<DoorCollider> m_LevelCompleteColliders;
        private LevelLoader m_LevelLoader;
        private void Start()
        {
            GameManager.Instance.currentGameState = GameManager.GameState.InGame;
            m_LevelLoader = GetComponent<LevelLoader>();

            OnLevelStart?.Invoke();
        }

        public void CheckCompleteCollider(DoorCollider colliderToCheck)
        {
            m_LevelCompleteColliders.Remove(colliderToCheck);

            if (m_LevelCompleteColliders.Count == 0)
            {
                SoundManager.Instance?.Play("Level Complete");
                
                m_LevelLoader.LoadLevel();

                //Saving the game specifying this was the last level completed
                GameManager.Instance.SaveGame(SceneManager.GetActiveScene().buildIndex + 1);
                OnLevelComplete?.Invoke();
            }
        }
    }
}
