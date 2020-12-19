using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.Events
{
    public class PressKeyEvent : MonoBehaviour
    {
        [SerializeField] private KeyCode m_keyToPress;
        [SerializeField] private UnityEvent onKeyPress;

        // Update is called once per frame
        void Update()
        {
             if (Input.GetKeyDown(m_keyToPress))
             {
                 onKeyPress.Invoke();
             }
        }
    }
}
