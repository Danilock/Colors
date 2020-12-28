using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Game.Traps
{
    /// <summary>
    /// Kill the character who collides with the water if doesn't match the same color.
    /// </summary>
    public class Water : MonoBehaviour
    {
        public enum WaterColor
        {
            Blue, Red, Yellow
        }

        [SerializeField] private WaterColor m_WaterColor;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (other.gameObject.layer != LayerMask.NameToLayer(m_WaterColor.ToString()))
                {
                    Destroy(other.gameObject);
                    FindObjectOfType<CinemachineImpulseSource>().GenerateImpulse();
                    GameManager.Instance.RestartLevel();
                }
            }
        }
    }
}