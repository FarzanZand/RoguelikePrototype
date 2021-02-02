using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// If FlipMode is set to enum MovementDirection, run the FlipToMoveDirection method.
// Method checks if the CurrentMovement from the CharacterControls script is a vector2 of Horizontal/Vertical movement
// Itt gets the value from it normalized, If x is higher than threshold, means Horizontal is moved. 
// Then checks if x is positive or negative, and flips if needed

public class CharacterFlip : CharacterComponents
{
    public enum FlipMode
    {
        MovementDirection,
        WeaponDirection
    }

    [SerializeField] private FlipMode flipMode = FlipMode.MovementDirection;
    [SerializeField] private float threshhold = 0.1f;

    protected override void HandleAbility()
    {
        base.HandleAbility();
        if (flipMode == FlipMode.MovementDirection)
        {
            FlipToMoveDirection();
        }
        else
        {
            FlipToWeaponDirection();
        }
    }

    
    private void FlipToMoveDirection()
    {
        if (controller.CurrentMovement.normalized.magnitude > threshhold)
        {
            if (controller.CurrentMovement.normalized.x > 0)
            {
                FaceDirection(1);
            }
            else
            {
                FaceDirection(-1);
            }
        }
    }

    private void FlipToWeaponDirection()
    {
        // Empty for now. 
    }

    private void FaceDirection(int newDirection)
    {
        if (newDirection == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
