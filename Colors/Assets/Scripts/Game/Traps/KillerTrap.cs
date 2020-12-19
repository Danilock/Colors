using System;
using System.Collections;
using System.Collections.Generic;
using Game.Color_System;
using UnityEngine;

namespace Game.Traps
{
    [RequireComponent(typeof(ColorManager))]
    public class KillerTrap : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Collided with player");
                Destroy(other.gameObject);
            }
        }
    }
}
