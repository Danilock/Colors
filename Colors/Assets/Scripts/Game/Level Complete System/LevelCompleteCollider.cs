using System;
using System.Collections;
using System.Collections.Generic;
using Game.Color_System;
using Game.Player;
using UnityEngine;

namespace Game.Level_Complete_System
{
    [RequireComponent(typeof(ColorManager))]
    public class LevelCompleteCollider : MonoBehaviour
    {
        private bool m_IsCompleted;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !m_IsCompleted)
            {
                PlayerInput.Instance.RemoveCharacterFromList(other.gameObject);
                m_IsCompleted = true;
            }
        }
    }
}
