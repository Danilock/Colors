using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Events
{
    public class Event_OnStart : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onStart;
        // Start is called before the first frame update
        void Start()
        {
            _onStart.Invoke();
        }
    }
}