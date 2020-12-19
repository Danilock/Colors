using System;
using System.Collections;
using System.Collections.Generic;
using Game.Color_System;
using UnityEngine;
using Cinemachine;

namespace Game.Traps
{
    [RequireComponent(typeof(ColorManager))]
    public class KillerTrap : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
