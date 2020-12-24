using System;
using System.Linq.Expressions;
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

        [SerializeField] private GameObject m_PickIndicator;
        private Material m_CharacterMaterial;
        private Material m_PickIndicatorMaterial;
        private bool m_inUse;
        public bool InUse
        {
            get => m_inUse;
            set => m_inUse = value;
        }
        [SerializeField] private LayerMask stopMovementLayers;
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
            m_CharacterMaterial = GetComponent<SpriteRenderer>().material;
            m_PickIndicatorMaterial = m_PickIndicator.GetComponent<SpriteRenderer>().material;
            ChangeIndicatorMaterial(false);
            
            if(InUse)
                m_CharacterMaterial.DisableKeyword("GHOST_ON");
            SetState(IdleState);
        }

        // Update is called once per frame
        void Update()
        {
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
        
        public bool CollidedWall()
        {
            bool linecastDetectWall = Physics2D.Linecast(transform.position,
                transform.position + (transform.right * transform.localScale.x * .1f),
                stopMovementLayers);

            return linecastDetectWall;
        }
        
        /// <summary>
        /// This methods makes the character jump.
        /// </summary>
        public void CharacterJump()
        {
            m_Ch2D.Move(PlayerInput.HorizontalInput * characterSpeed, false, true);
        }

        public void EnableGhostMaterial(bool value)
        {
            if (value)
            {
                m_CharacterMaterial.EnableKeyword("GHOST_ON");
            }
            else
            {
                m_CharacterMaterial.DisableKeyword("GHOST_ON");
            }
        }

        public void ChangeIndicatorMaterial(bool state)
        {
            if (state)
            {
                m_PickIndicatorMaterial.EnableKeyword("GHOST_ON");
            }
            else
            {
                m_PickIndicatorMaterial.DisableKeyword("GHOST_ON");
            }
        }

        public void SetIndicator(bool state)
        {
            m_PickIndicator.SetActive(state);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + (transform.right * transform.localScale.x * .1f) );
        }
    }
}
