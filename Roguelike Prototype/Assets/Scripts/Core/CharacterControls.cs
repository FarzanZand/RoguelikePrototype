using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Can move character if NormalMovement is true. 
// Normalized returns the magnitude of the larger value as 1.0, and other as < 1 if it is less.

// This script shows what input the character is getting and moves it to proper scripts

public class CharacterControls : MonoBehaviour
{
    private Rigidbody2D myRigidBody2D;
    public Vector2 CurrentMovement { get; set; }
    public bool NormalMovement { get; set; }
    private Vector2 recoilMovement; 

    void Start()
    {
        NormalMovement = true; 
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Recoil(); 
        
        if (NormalMovement)
        {
        MoveCharacter();
        }
    }

    public void ApplyRecoil(Vector2 recoilDirection, float recoilForce) 
    {
        recoilMovement = recoilDirection.normalized * recoilForce; //Only need the direction, so normalize it
    }

    public void MoveCharacter()
    {
        Vector2 currentMovePosition = myRigidBody2D.position + CurrentMovement * Time.fixedDeltaTime;
        myRigidBody2D.MovePosition(currentMovePosition);
    }

    public void MovePosition(Vector2 newPosition)
    {
        myRigidBody2D.MovePosition(newPosition);
    }

    public void SetMovement(Vector2 currentMovement) // changed from newPosition cause this makes more sense
    {
        CurrentMovement = currentMovement; 
    }

    // If enough recoil to move, recoil the body
    private void Recoil()
    {
        if(recoilMovement.magnitude >0.1f)
        {
            myRigidBody2D.AddForce(recoilMovement); 
        }
    }
}
