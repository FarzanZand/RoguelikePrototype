using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    private Rigidbody2D myRigidBody2D;
    public Vector2 CurrentMovement { get; set; }

    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        Vector2 currentMovePosition = myRigidBody2D.position + CurrentMovement * Time.fixedDeltaTime;
        myRigidBody2D.MovePosition(currentMovePosition);
    }

    public void SetMovement(Vector2 newPosition)
    {
        CurrentMovement = newPosition; 
    }
}
