using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Game.Player
{
    public class PlayerInput : MonoBehaviour
    {
        #region Singleton

        private static PlayerInput _instance;

        public static PlayerInput Instance
        {
            get
            {
                if (_instance == null)
                    Debug.LogError("There's no player input script in the Scene");

                return _instance;
            }
        }
        #endregion
        
        [SerializeField] private List<Character> m_Characters;
        [SerializeField] private Character m_CurrentCharacter;

        private int m_IndexCharacter = 0;
        public  static float HorizontalInput { get; private set; }

        private void Awake()
        {
            #region Initializing Singleton

            

            PlayerInput[] _inputs = FindObjectsOfType<PlayerInput>();

            if (_inputs.Length > 1)
            {
                Debug.LogError("Can't be two inputs in the same scene!");

                foreach (var inputObj in _inputs)
                {
                    Debug.LogError(inputObj.gameObject.name);
                }
            }
            
            if (_instance != null && _instance != this)
                Destroy(gameObject);
            else
                _instance = this;
            #endregion
        }

        // Start is called before the first frame update
        void Start()
        {
            //Initiating the game with the first character in herarchy
            m_CurrentCharacter = m_Characters[0];
            m_CurrentCharacter.InUse = true;
        }

        // Update is called once per frame
        void Update()
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal");
            
            if (Input.GetKeyDown(KeyCode.E))//If E is pressed select the next character
            {
                m_IndexCharacter = (m_IndexCharacter + 1) % m_Characters.Count;
                ChangeCharacter(m_Characters[m_IndexCharacter]);
            }
            else if(Input.GetKeyDown(KeyCode.Q))//If Q is pressed select the previous character
            {
                if (m_IndexCharacter > 0)
                {
                    m_IndexCharacter--;
                }

                else
                {
                    m_IndexCharacter = m_Characters.Count - 1;
                }
                ChangeCharacter(m_Characters[m_IndexCharacter]);
            }
        }
        
        [ContextMenu("Add Characters")]
        void FindAllCharacters()
        {
            Character[] charactersInScene = FindObjectsOfType<Character>();
            m_Characters = new List<Character>(charactersInScene);
        }

        void ChangeCharacter(Character newCharacter)
        {
            m_CurrentCharacter.InUse = false;//sets the actual character state to false
            m_CurrentCharacter.SetState(m_CurrentCharacter.IdleState);

            m_CurrentCharacter = newCharacter;//add the new character as the current one
            m_CurrentCharacter.InUse = true;//put's it's state as true
        }
        
        /// <summary>
        /// Removes a character from the list.
        /// </summary>
        /// <param name="characterToRemove"></param>
        public void RemoveCharacterFromList(GameObject characterToRemove)
        {
            for (int i = 0; i < m_Characters.Count; i++)
            {
                if (m_Characters[i].gameObject == characterToRemove)//if find the character, it'll remove it from the list
                {
                    m_Characters.Remove(m_Characters[i]);
                }
            }
            
            //If there are characters without completing the level then select the first of them
            if(m_Characters.Count > 0)
                ChangeCharacter(m_Characters[0]);
        }
    }
}