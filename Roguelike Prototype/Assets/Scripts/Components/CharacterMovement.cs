using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : CharacterComponents
{

    [SerializeField] private float walkSpeed = 6f;
    public float MoveSpeed { get; set; }

    protected override void Start()
    {
        base.Start();
        MoveSpeed = walkSpeed;
    }

    protected override void HandleAbility()
    {
        base.HandleAbility();
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        Vector2 movementNormalized = movement.normalized; // Fixes horizontal movement speed
        Vector2 movementSpeed = movementNormalized * MoveSpeed;
        controller.SetMovement(movementSpeed);
    }

    public void ResetSpeed()
    {
        MoveSpeed = walkSpeed;
    }
}