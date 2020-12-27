using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Events
{
    public class Event_OnTriggerEnter2D : MonoBehaviour
    {
        [SerializeField] private UnityEvent onTriggerEvent;
        [SerializeField] private string targetTag;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(targetTag))
            {
                onTriggerEvent.Invoke();
            }
        }
    }
}
