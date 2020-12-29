using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
namespace Game.Player
{
    
    public class CameraFollowCharacter : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera m_VirtualCamera;

        private void Update()
        {
            m_VirtualCamera.Follow = PlayerInput.Instance.CurrentCharacter.transform;
        }
    }
}
