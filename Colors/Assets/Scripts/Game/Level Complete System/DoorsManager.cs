using System;
using System.Collections;
using System.Collections.Generic;
using Game.Sound;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Level_Complete_System
{
    [RequireComponent(typeof(LevelLoader))]
    public class DoorsManager : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnAllDoorsReached;
        [SerializeField] private List<DoorCollider> m_LevelCompleteColliders;

        private void Start()
        {
            GameManager.Instance.currentGameState = GameManager.GameState.InGame; 
        }

        public void CheckCompleteCollider(DoorCollider colliderToCheck)
        {
            m_LevelCompleteColliders.Remove(colliderToCheck);

            if (m_LevelCompleteColliders.Count == 0)
            {
                SoundManager.Instance.Play("Level Complete");
                OnAllDoorsReached.Invoke();
            }
        }
    }
}
