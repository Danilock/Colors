using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Events
{
    public class Event_OnTriggerExit2D : MonoBehaviour
    {
        [SerializeField] private string TargetTag;
        [SerializeField] private UnityEvent OnTriggerExitEvent;
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(TargetTag))
            {
                OnTriggerExitEvent.Invoke();
            }
        }
    }
}