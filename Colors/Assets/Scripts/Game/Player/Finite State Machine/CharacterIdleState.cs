using System.Collections;
using System.Collections.Generic;
using Game.Player;
using Game.Player.Finite_State_Machine;
using UnityEngine;

public class CharacterIdleState : CharacterBaseState
{
    public override void EnterState(Character character)
    {
        character.characterAnimator.SetFloat("Speed", 0f);
        character.rgb2D.velocity = Vector2.zero;
    }

    public override void Update(Character character)
    {
        if (Input.GetButtonDown("Jump"))
        {
            character.CharacterJump();
            character.SetState(character.JumpState);
        }
    }

    public override void FixedUpdate(Character character)
    {
        character.m_Ch2D.Move(PlayerInput.HorizontalInput * character.characterSpeed, false, false);

        if (character.rgb2D.velocity.magnitude > .1f)
        {
            character.characterAnimator.SetFloat("Speed", Mathf.Abs(PlayerInput.HorizontalInput));
            character.SetState(character.MovingState);
        }
    }

    public override void ExitState(Character character)
    {
        
    }
}
