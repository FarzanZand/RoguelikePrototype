using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Parent class for character. Handle functions are called like update functions in child classes

public class CharacterComponents : MonoBehaviour
{

    protected float horizontalInput;
    protected float verticalInput;

    protected CharacterControls controller;
    protected CharacterMovement characterMovement;

    protected virtual void Start()
    {
        controller = GetComponent<CharacterControls>();
        characterMovement = GetComponent<CharacterMovement>();
    }

    protected virtual void Update()
    {
        HandleAbility();
    }

    protected virtual void HandleAbility()
    {
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
