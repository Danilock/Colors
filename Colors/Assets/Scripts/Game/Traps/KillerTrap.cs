using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Game.Color_System;
using UnityEngine;
using Cinemachine;
using Game.Player;
using UnityEngine.Assertions.Comparers;
using UnityEngine.Events;

namespace Game.Traps
{
    [RequireComponent(typeof(ColorManager))]
    public class KillerTrap : MonoBehaviour, IDestructible
    {
        private Animator m_TrapAnimator;

        private void Start()
        {
            m_TrapAnimator = GetComponent<Animator>();
        }

        [SerializeField] private UnityEvent OnKill;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(other.gameObject);
                OnKill.Invoke();
                FindObjectOfType<CinemachineImpulseSource>().GenerateImpulse();
                GameManager.Instance.RestartLevel();
            }
        }

        public void DesactivateTrap()
        {
            m_TrapAnimator.SetTrigger("DesactivateTrap");
        }

        public void DestroyMe()
        {
            Destroy(gameObject);
        }
    }
}
