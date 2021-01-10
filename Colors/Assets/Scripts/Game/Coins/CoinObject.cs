using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Color_System;
using Game.Sound;

namespace Game.Coins {
    public class CoinObject : MonoBehaviour
    {
        private CoinManager m_CoinManager;
        [SerializeField] private ColorManager.objColor CoinColor;
        [SerializeField] private GameObject m_pickParticleEffect;

        private void Start()
        {
            m_CoinManager = FindObjectOfType<CoinManager>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && collision.gameObject.layer == LayerMask.NameToLayer(CoinColor.ToString()))
            {
                SoundManager.Instance.Play("Coin");
                m_CoinManager.AddCoins(1, CoinColor);
                Instantiate(m_pickParticleEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
