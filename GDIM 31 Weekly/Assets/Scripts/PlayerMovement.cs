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
    BoxCollider2D bc; 
    Animator playerAnimator; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>(); 
    }


    void Update()
    {
        Run();
        FlipSprite();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>(); 
    }
    void OnJump(InputValue value)
    {
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
