using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Game.Color_System;
using Game.Player;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Level_Complete_System
{
    [RequireComponent(typeof(ColorManager))]
    public class DoorCollider : MonoBehaviour
    {
        [SerializeField] private UnityEvent m_OnColliderCheck;
        private CinemachineImpulseSource m_Impulse;
        private DoorsManager m_DoorsManager;
        private bool m_IsCompleted;

        private void Start()
        {
            m_DoorsManager = GetComponentInParent<DoorsManager>();
            m_Impulse = GetComponent<CinemachineImpulseSource>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !m_IsCompleted)
            {
                PlayerInput.Instance.RemoveCharacterFromList(other.gameObject);
                m_DoorsManager.CheckCompleteCollider(this);
                m_OnColliderCheck.Invoke();
                m_Impulse.GenerateImpulse();
                m_IsCompleted = true;
            }
        }
    }
}
