using System.Collections;
using System.Collections.Generic;
using Game.Player;
using Game.Player.Finite_State_Machine;
using UnityEngine;

public class CharacterIdleState : CharacterBaseState
{
    public override void EnterState(Character character)
    {
        
    }

    public override void Update(Character character)
    {
        if (Input.GetButtonDown("Jump"))
        {
            character.CharacterJump();
        }
    }

    public override void FixedUpdate(Character character)
    {
        character.m_Ch2D.Move(PlayerInput.HorizontalInput * character.characterSpeed, false, false);

        if (character.rgb2D.velocity.magnitude > .1f)
        {
            character.SetState(character.MovingState);
        }
    }

    public override void ExitState(Character character)
    {
        
    }
}
