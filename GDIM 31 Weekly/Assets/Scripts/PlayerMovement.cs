using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(3f, 3f); 
    Vector2 moveInput;
    Rigidbody2D rb;
    CapsuleCollider2D bodyCollider; 
    BoxCollider2D feetCollider; 
    Animator playerAnimator;

    bool isAlive = true; 
    void Start()
    {
        //Initializing components
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        feetCollider = GetComponent<BoxCollider2D>();
        bodyCollider = GetComponent<CapsuleCollider2D>(); 
    }


    void Update()
    {
        //Retrieve run and flipping direction every frame. Check for jump separately
        if(!isAlive) { return; }
        Run();
        FlipSprite();
        Die(); 
    }
    void OnMove(InputValue value)
    {
        if(!isAlive) { return; }
        moveInput = value.Get<Vector2>(); 
    }
    void OnJump(InputValue value)
    {
        //Instead of raycast, use a simple collision detection with Ground layer to determine if player is on a platform
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            return; 
        if(value.isPressed)
        {
            rb.velocity += new Vector2(0f, jumpSpeed); 
        }
    }
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y); 
        rb.velocity = playerVelocity;
        //Epsilon is there specifically to prevent the player sprite from always facing right when standing still
        bool playerMoving = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("isWalking", playerMoving); 
    }

    void FlipSprite()
    {
        bool playerMoving = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon; 
        if(playerMoving)
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f); 
    }

    void Die()
    {
        if(bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies")))
        {
            isAlive = false;
            playerAnimator.SetTrigger("Dying");
            rb.velocity = deathKick; 
        }

    }

}
