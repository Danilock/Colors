using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Game.Coins;
using Game.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI blueCoinsText;
        [SerializeField] private TextMeshProUGUI redCoinsText;
        [SerializeField] private TextMeshProUGUI yellowCoinsText;
        private CoinManager m_CoinManager;

        [Header("Current Character Selected UI")] 
        [SerializeField] private Transform[] _charactersImagePosition;

        [SerializeField] private LerpMovement _currentCharacterIndicator;
        private void Start()
        {
            m_CoinManager = FindObjectOfType<CoinManager>();

            m_CoinManager.OnCoinAddedAction += UpdateCoinsInformation;

            PlayerInput.onChange += UpdateCurrentCharacter;
        }

        private void OnDisable()
        {
            m_CoinManager.OnCoinAddedAction -= UpdateCoinsInformation;
            PlayerInput.onChange -= UpdateCurrentCharacter;
        }

        public void UpdateCoinsInformation()
        {
            blueCoinsText.text = m_CoinManager.BlueCoins.ToString();
            redCoinsText.text = m_CoinManager.RedCoins.ToString();
            yellowCoinsText.text = m_CoinManager.YellowCoins.ToString();
        }

        public void UpdateCurrentCharacter()
        {
            _currentCharacterIndicator.Move(_charactersImagePosition[PlayerInput.Instance.IndexCharacter]);
        }
    }
}