using System;
using Game.Player.Finite_State_Machine;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CharacterController2D))]
    public class Character : MonoBehaviour
    {
        #region Gameplay

        [FormerlySerializedAs("m_CharacterSpeed")] public float characterSpeed = 5f;
        [HideInInspector] public CharacterController2D m_Ch2D;
        public Rigidbody2D rgb2D;
        public bool InUse { get; set; }
        #endregion

        #region Finite State Machine
        private CharacterBaseState m_CurrentState;
        public CharacterIdleState IdleState = new CharacterIdleState();
        public CharacterMovingState MovingState = new CharacterMovingState();
        public CharacterJumpState JumpState = new CharacterJumpState();
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            m_Ch2D = GetComponent<CharacterController2D>();
            rgb2D = GetComponent<Rigidbody2D>();
            
            SetState(IdleState);
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(gameObject.name + m_CurrentState);
            if (InUse)
            {
                m_CurrentState.Update(this);
            }
        }

        private void FixedUpdate()
        {
            if (InUse)
            {
                m_CurrentState.FixedUpdate(this);
            }
        }

        /// <summary>
        /// Sets the character state executing the Exit State and Enter State.
        /// </summary>
        /// <param name="newState"></param>
        public void SetState(CharacterBaseState newState)
        {
            if (m_CurrentState != null)
                m_CurrentState.ExitState(this);
            
            m_CurrentState = newState;
            m_CurrentState.EnterState(this);
        }
    }
}
