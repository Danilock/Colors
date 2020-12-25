using System.Collections;
using System.Collections.Generic;
using Game.Color_System;
using UnityEngine;

namespace Game.Coins
{
    public class CoinManager : MonoBehaviour
    {
        public delegate void OnCoinAdded();
        public event OnCoinAdded OnCoinAddedAction;
        #region Coins
        public int RedCoins { get; private set; }
        public int BlueCoins { get; private set; }
        public int YellowCoins { get; private set; }
        #endregion

        private static CoinManager m_instance;
        public static CoinManager Instance
        {
            get
            {
                if (m_instance == null)
                    Debug.LogError("No Coin Manager found");

                return m_instance;
            }
        }

        void Awake() => m_instance = this;

        public void AddCoins(int amount, ColorManager.objColor coinColor)
        {
            switch (coinColor)
            {
                case ColorManager.objColor.Blue:
                    BlueCoins += 1;
                    break;
                case ColorManager.objColor.Red:
                    RedCoins += 1;
                    break;
                case  ColorManager.objColor.Yellow:
                    YellowCoins += 1;
                    break;
            }
            
            OnCoinAddedAction?.Invoke();
        }
    }
}
