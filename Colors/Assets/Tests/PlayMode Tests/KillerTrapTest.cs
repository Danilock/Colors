using System.Collections;
using System.Collections.Generic;
using Game.Color_System;
using Game.Player;
using Game.Traps;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class KillerTrapTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void KillerTrapTestSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator KillerTrapTestWithEnumeratorPasses()
        {
            //-----What happens if killer trap collides with an object with a different target object
            
            //Setting player
            GameObject player = new GameObject("Player Clone");
            player.tag = "Player";
            ColorManager playerColor = player.AddComponent<ColorManager>();
            playerColor.ChangeColor(ColorManager.objColor.Red);
            player.AddComponent<BoxCollider2D>();
            player.AddComponent<Rigidbody2D>();
            
            //Setting trap
            GameObject trap = new GameObject("Trap");
            trap.AddComponent<KillerTrap>();
            ColorManager trapColor = trap.GetComponent<ColorManager>();
            trapColor.ChangeColor(ColorManager.objColor.Blue);
            trap.AddComponent<BoxCollider2D>();

            trap.transform.position = player.transform.position;
            
            yield return new WaitForSeconds(1f);
            
            //The object(player) is suppose  to still alive
            Assert.IsNotNull(player);
            
        }
    }
}
