using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Traps
{
    [RequireComponent(typeof(AreaEffector2D), typeof(Collider2D))]
    public class Ventiler : MonoBehaviour
    {
        [SerializeField] private LayerMask colliderMaskForAreaEffector;
        private AreaEffector2D m_Effector2D;
        // Start is called before the first frame update
        void Start()
        {
            m_Effector2D = GetComponent<AreaEffector2D>();

            m_Effector2D.colliderMask = colliderMaskForAreaEffector;
        }
    }
}