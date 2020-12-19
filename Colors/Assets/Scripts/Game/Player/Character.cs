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
        [HideInInspector] public Rigidbody2D rgb2D;
        [HideInInspector] public Animator characterAnimator;
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
            characterAnimator = GetComponent<Animator>();
            
            SetState(IdleState);
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(m_CurrentState);
            if (InUse && GameManager.Instance.currentGameState == GameManager.GameState.InGame)
            {
                m_CurrentState.Update(this);
            }
        }

        private void FixedUpdate()
        {
            if (InUse && GameManager.Instance.currentGameState == GameManager.GameState.InGame)
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
            m_CurrentState?.ExitState(this);

            m_CurrentState = newState;
            m_CurrentState.EnterState(this);
        }
        
        /// <summary>
        /// This methods makes the character jump.
        /// </summary>
        public void CharacterJump()
        {
            m_Ch2D.Move(PlayerInput.HorizontalInput * characterSpeed, false, true);
        }
    }
}
