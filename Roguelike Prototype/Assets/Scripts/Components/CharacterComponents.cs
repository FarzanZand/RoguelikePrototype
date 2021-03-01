using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Parent class for character. Handle functions are called like update functions in child classes
// Gives access to necessary parent classes. Like a parent hub. 

// HandleAbility manages ability logic
// HandleInput handles input from player
// InternalInput handles input from code. But is this necessary? 

public class CharacterComponents : MonoBehaviour
{

    protected float horizontalInput;
    protected float verticalInput;

    protected CharacterControls controller;         // Access to control input from player
    protected CharacterMovement characterMovement;  // Access to how character should be moved
    protected CharacterWeapon characterWeapon; 
    protected Animator animator;
    protected Character character;

    protected virtual void Start()
    {
        controller = GetComponent<CharacterControls>();
        character = GetComponent<Character>();
        characterWeapon = GetComponent<CharacterWeapon>(); 
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
