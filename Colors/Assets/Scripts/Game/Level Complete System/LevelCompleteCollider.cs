using System;
using System.Collections;
using System.Collections.Generic;
using Game.Color_System;
using Game.Player;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Level_Complete_System
{
    [RequireComponent(typeof(ColorManager))]
    public class LevelCompleteCollider : MonoBehaviour
    {
        [SerializeField] private UnityEvent m_OnColliderCheck;
        private LevelCompleteManager m_LevelCompleteManager;

        private void Start()
        {
            m_LevelCompleteManager = GetComponentInParent<LevelCompleteManager>();
        }

        private bool m_IsCompleted;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !m_IsCompleted)
            {
                PlayerInput.Instance.RemoveCharacterFromList(other.gameObject);
                m_LevelCompleteManager.CheckCompleteCollider(this);
                m_OnColliderCheck.Invoke();
                m_IsCompleted = true;
            }
        }
    }
}
