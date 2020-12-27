using System;
using System.Collections;
using System.Collections.Generic;
using Game.Coins;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private Text blueCoinsText;
        [SerializeField] private Text redCoinsText;
        [SerializeField] private Text yellowCoinsText;
        private CoinManager m_CoinManager;
        private void Start()
        {
            m_CoinManager = FindObjectOfType<CoinManager>();

            m_CoinManager.OnCoinAddedAction += UpdateCoinsInformation;
        }

        private void OnDisable()
        {
            m_CoinManager.OnCoinAddedAction -= UpdateCoinsInformation;
        }

        public void UpdateCoinsInformation()
        {
            blueCoinsText.text = m_CoinManager.BlueCoins.ToString();
            redCoinsText.text = m_CoinManager.RedCoins.ToString();
            yellowCoinsText.text = m_CoinManager.YellowCoins.ToString();
        }
    }
}