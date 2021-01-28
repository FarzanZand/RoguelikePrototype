using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Can move character if NormalMovement is true. 

public class CharacterControls : MonoBehaviour
{
    private Rigidbody2D myRigidBody2D;
    public Vector2 CurrentMovement { get; set; }
    public bool NormalMovement { get; set; }

    void Start()
    {
        NormalMovement = true; 
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (NormalMovement)
        {
        MoveCharacter();
        }
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

    public void SetMovement(Vector2 newPosition)
    {
        CurrentMovement = newPosition; 
    }
}
