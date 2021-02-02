using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Parent class for character. Handle functions are called like update functions in child classes
// Gives access to necessary parent classes. Like a parent hub. 

public class CharacterComponents : MonoBehaviour
{

    protected float horizontalInput;
    protected float verticalInput;

    protected CharacterControls controller;         // Access to control input from player
    protected CharacterMovement characterMovement;  // Access to how character should be moved
    protected Animator animator;

    protected virtual void Start()
    {
        controller = GetComponent<CharacterControls>();
        characterMovement = GetComponent<CharacterMovement>();
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        HandleAbility();
    }

    protected virtual void HandleAbility()
    {
        // Move these two to update for cleaner code by end if that would work
        InternalInput();
        HandleInput();
    }

    protected virtual void HandleInput()
    {

    }

    protected virtual void InternalInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
}
