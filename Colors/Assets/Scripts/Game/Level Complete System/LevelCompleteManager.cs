using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Level_Complete_System
{
    public class LevelCompleteManager : MonoBehaviour
    {
        [SerializeField] private List<LevelCompleteCollider> m_LevelCompleteColliders;

        public void CheckCompleteCollider(LevelCompleteCollider colliderToCheck)
        {
            m_LevelCompleteColliders.Remove(colliderToCheck);

            if (m_LevelCompleteColliders.Count == 0)
                GameManager.Instance.currentGameState = GameManager.GameState.PlayerWin;
        }
    }
}
