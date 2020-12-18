using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Character[] m_Characters;
        [SerializeField] private Character m_CurrentCharacter;

        private int m_IndexCharacter = 0;
        public  static float HorizontalInput { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            m_CurrentCharacter = m_Characters[0];
            m_CurrentCharacter.InUse = true;
        }

        // Update is called once per frame
        void Update()
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal");
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                m_IndexCharacter = (m_IndexCharacter + 1) % m_Characters.Length;
                ChangeCharacter(m_Characters[m_IndexCharacter]);
            }
            else if(Input.GetKeyDown(KeyCode.Q))
            {
                if (m_IndexCharacter > 0)
                {
                    m_IndexCharacter--;
                }

                else
                {
                    m_IndexCharacter = m_Characters.Length - 1;
                }
                ChangeCharacter(m_Characters[m_IndexCharacter]);
            }
        }
        
        [ContextMenu("Add Characters")]
        void FindAllCharacters()
        {
            m_Characters = FindObjectsOfType<Character>();
        }

        void ChangeCharacter(Character newCharacter)
        {
            m_CurrentCharacter.InUse = false;//sets the actual character state to false
            m_CurrentCharacter.SetState(m_CurrentCharacter.IdleState);

            m_CurrentCharacter = newCharacter;//add the new character as the current one
            m_CurrentCharacter.InUse = true;//put's it's state as true
        }
    }
}