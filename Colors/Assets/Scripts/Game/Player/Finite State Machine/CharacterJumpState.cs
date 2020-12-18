using System.Collections;
using System.Collections.Generic;
using Game.Player;
using Game.Player.Finite_State_Machine;
using UnityEngine;

public class CharacterJumpState : CharacterBaseState
{
    public override void EnterState(Character character)
    {
        
    }

    public override void Update(Character character)
    {
        if (character.m_Ch2D.m_Grounded)
        {
            character.SetState(character.IdleState);
        }
    }

    public override void FixedUpdate(Character character)
    {
        if (character.m_Ch2D.m_Grounded)
        {
            character.SetState(character.IdleState);
        }
    }

    public override void ExitState(Character character)
    {
        
    }
}
