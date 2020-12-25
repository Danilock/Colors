using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Color_System;

namespace Game.Coins {
    [RequireComponent(typeof(ColorManager))]
    public class CoinObject : MonoBehaviour
    {
        private ColorManager m_CoinColor;

        private void Start()
        {
            m_CoinColor = GetComponent<ColorManager>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                CoinManager.Instance.AddCoins(1, m_CoinColor.objectColor);
                Destroy(gameObject);
            }
        }
    }
}
