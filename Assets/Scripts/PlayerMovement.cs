using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 4f;
    [SerializeField] float jumpSpeed = 4f;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myCollider;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<CapsuleCollider2D>();

    }

    void Update()
    {
        Run();
        FlipSprite();
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);

        }
    }

    private void Run()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        if (playerHasHorizontalSpeed) //Changes the animation state from Idle to Run if running
        {
            myAnimator.SetBool("isRunning", true);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }
    }

    void OnMove(InputValue val)
    {
        moveInput = val.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void OnJump(InputValue val)
    {
        if (val.isPressed)
        {
            if (myCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) //If player is touching ground allow jump
            {
                myRigidbody.velocity += new Vector2(0f, jumpSpeed);
            }
        }
    }
}
