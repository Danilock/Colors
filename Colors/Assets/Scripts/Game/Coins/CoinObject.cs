using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Color_System;

namespace Game.Coins {
    [RequireComponent(typeof(ColorManager))]
    public class CoinObject : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                CoinManager.Instance.AddCoins(1);
                Destroy(gameObject);
            }
        }
    }
}
