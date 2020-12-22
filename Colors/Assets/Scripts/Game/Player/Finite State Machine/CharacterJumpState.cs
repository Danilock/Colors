using System.Collections;
using System.Collections.Generic;
using Game.Player;
using Game.Player.Finite_State_Machine;
using UnityEngine;

public class CharacterJumpState : CharacterBaseState
{
    public override void EnterState(Character character)
    {
        character.m_Ch2D.CrouchSpeed /= 1.2f;
    }

    public override void Update(Character character)
    {
        if (character.m_Ch2D.m_Grounded && character.rgb2D.velocity.y <= .1f)
        {
            character.SetState(character.IdleState);
        }

        #region AirControl Checker
        if (character.CollidedWall())
        {
            character.m_Ch2D.AirControl = false;
        }
        else
        {
            character.m_Ch2D.AirControl = true;
        }
        #endregion
    }

    public override void FixedUpdate(Character character)
    {
        character.m_Ch2D.Move(PlayerInput.HorizontalInput * character.characterSpeed, false, false);
        character.characterAnimator.SetFloat("Speed", Mathf.Abs(PlayerInput.HorizontalInput));
    }

    public override void ExitState(Character character)
    {
        character.m_Ch2D.AirControl = true;
        character.m_Ch2D.CrouchSpeed *= 1.2f;
    }
}
