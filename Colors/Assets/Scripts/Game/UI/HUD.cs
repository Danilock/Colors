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

        private void Start()
        {
            CoinManager.Instance.OnCoinAddedAction += UpdateCoinsInformation;
        }

        private void OnEnable()
        {
            CoinManager.Instance.OnCoinAddedAction += UpdateCoinsInformation;
        }

        private void OnDisable()
        {
            CoinManager.Instance.OnCoinAddedAction -= UpdateCoinsInformation;
        }

        public void UpdateCoinsInformation()
        {
            blueCoinsText.text = CoinManager.Instance.BlueCoins.ToString();
            redCoinsText.text = CoinManager.Instance.RedCoins.ToString();
            yellowCoinsText.text = CoinManager.Instance.YellowCoins.ToString();
        }
    }
}