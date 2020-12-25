using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game.Coins;
using Game.Player;
using Game.Color_System;

namespace Tests
{
    public class TakeCoinTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TakeCoinTestSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TakeCoinTestWithEnumeratorPasses()
        {
            #region Set-Up CoinManager Object
            GameObject coinManagerObject = new GameObject("CoinManager");
            coinManagerObject.AddComponent<CoinManager>();
            #endregion

            #region Set-Up Player
            GameObject player = new GameObject("Player");
            ColorManager playerColorManager = player.AddComponent<ColorManager>();
            player.AddComponent<Rigidbody2D>();
            player.AddComponent<BoxCollider2D>();
            player.tag = "Player";
            playerColorManager.ChangeColor(ColorManager.objColor.Red);
            #endregion

            #region Set-Up Coin
            GameObject coin = new GameObject("Coin");
            ColorManager coinColor = coin.AddComponent<ColorManager>();
            Collider2D coinCollider = coin.AddComponent<BoxCollider2D>();
            coin.AddComponent<CoinObject>();
            coinCollider.isTrigger = true;
            coinColor.ChangeColor(ColorManager.objColor.Red);
            #endregion

            coin.transform.position = player.transform.position;

            yield return new WaitForSeconds(1f);
            int actualCoins = CoinManager.Instance.RedCoins;
            Assert.AreEqual(1, actualCoins);
            Assert.IsTrue(coin == null);
        }
    }
}
