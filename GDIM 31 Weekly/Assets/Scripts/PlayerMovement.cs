using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    Vector2 moveInput;
    Rigidbody2D rb;
    CapsuleCollider2D cc; 
    BoxCollider2D bc; 
    Animator playerAnimator; 
    void Start()
    {
        //Initializing components
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        cc = GetComponent<CapsuleCollider2D>(); 
    }


    void Update()
    {
        //Retrieve run and flipping direction every frame. Check for jump separately
        Run();
        FlipSprite();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>(); 
    }
    void OnJump(InputValue value)
    {
        //Instead of raycast, use a simple collision detection with Ground layer to determine if player is on a platform
        if (!bc.IsTouchingLayers(LayerMask.GetMask("Ground")))
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
}
