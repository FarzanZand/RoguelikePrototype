using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float speed = 100f;
    [SerializeField] private float acceleration = 0f; 

    public Vector2 Direction { get; set; }
    public bool FacingRight { get; set; }
    public float Speed { get; set; }

    private Rigidbody2D myRigidBody2D;
    private SpriteRenderer spriteRenderer;

    private Vector2 movement;

    void Awake()
    {
        Speed = speed;
        FacingRight = true;

        myRigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    private void FixedUpdate()
    {
        MoveProjectile(); 
    }

    public void MoveProjectile()
    {
        movement = Direction * (Speed / 10f) * Time.fixedDeltaTime;
        myRigidBody2D.MovePosition(myRigidBody2D.position + movement);

        Speed += acceleration * Time.deltaTime;
    }

    public void FlipProjectile()
    {
        if(spriteRenderer != null)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    public void SetDirection(Vector2 newDirection, Quaternion rotation, bool isFacingRight = true)
    {
        Direction = newDirection;

        // if it isn't facing right, flip it
        if(FacingRight != isFacingRight)
        {
            FlipProjectile(); 
        }

        transform.rotation = rotation; 
    }

    public void ResetProjectile() 
    {
        spriteRenderer.flipX = false;
    }
}
