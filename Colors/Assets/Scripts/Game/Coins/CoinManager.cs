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

        public void AddCoins(int amount, ColorManager.objColor coinColor)
        {
            switch (coinColor)
            {
                case ColorManager.objColor.Blue:
                    BlueCoins += amount;
                    break;
                case ColorManager.objColor.Red:
                    RedCoins += amount;
                    break;
                case  ColorManager.objColor.Yellow:
                    YellowCoins += amount;
                    break;
            }
            
            OnCoinAddedAction?.Invoke();
        }
    }
}
