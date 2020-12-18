using Game.Player.Finite_State_Machine;
using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CharacterController2D))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private float m_CharacterSpeed = 5f;
        private CharacterController2D m_Ch2D;
        private CharacterBaseState m_CurrentState;
        public bool InUse { get; set; }
        // Start is called before the first frame update
        void Start()
        {
            m_Ch2D = GetComponent<CharacterController2D>();
        }

        // Update is called once per frame
        void Update()
        {
            m_CurrentState.Update(this);
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
