using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Why it moves. CharacterComponents registers horizontal/vertical input. 
// HandleAbility calls MoveCharacter, which sets up the movementSpeed
// movementSpeed is then sent to CharacterControls via controller.SetMovement, where it sets CurrentMovement
// If NormalMovement is True, MoveCharacter is run
// There it takes the CurrentMovement and move, saves it in Vector2 CurrentPosition
// currentPosition is then passed through the RigidBody2D method MovePosition for movement

public class CharacterMovement : CharacterComponents
{

    [SerializeField] private float walkSpeed = 6f;
    public float MoveSpeed { get; set; }

    protected override void Start()
    {
        base.Start();
        MoveSpeed = walkSpeed;
    }

    // Calls like an update function
    protected override void HandleAbility()
    {
        base.HandleAbility();
        MoveCharacter();
    }

    // Sets up characterMovement to pass to controller
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