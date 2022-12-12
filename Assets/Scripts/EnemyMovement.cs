using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    [SerializeField] float moveSpeed = 4f;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }

    private void FlipEnemyFacing() //flips the sprite when hits the wall
    {
        //transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), 1f);
        transform.localScale = new Vector2((Mathf.Sign(myRigidbody.velocity.x)), 1f);
    }
}
