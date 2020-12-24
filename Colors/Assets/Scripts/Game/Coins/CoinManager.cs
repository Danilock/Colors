using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Coins
{
    public class CoinManager : MonoBehaviour
    {
        private int m_currentPoints;

        public int CurrentCoins
        {
            get { return m_currentPoints; }
            private set { m_currentPoints = value; }
        }

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

        public void AddCoins(int amount)
        {
            CurrentCoins += amount;
        }
    }
}
