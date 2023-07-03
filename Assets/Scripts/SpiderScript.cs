using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour
{
    [SerializeField] private float patrolRange = 7f;
    [SerializeField] private float moveSpeed = 10f;
    private float _patrolStartPositionX;
    private bool _movingRight = true;
    [SerializeField] private Rigidbody2D enemyRigidbody2D;


    private void Start()
    {
        _patrolStartPositionX = transform.position.x;
    }


    void FixedUpdate()
    {
        // Check if the enemy has reached the left or right boundary
        if (transform.position.x >= _patrolStartPositionX+patrolRange)
        {
            _movingRight = false;
            transform.Rotate(0f, 180f, 0f);
            
        }
        else if (transform.position.x <= _patrolStartPositionX)
        {
            _movingRight = true;
            transform.Rotate(0f, 180f, 0f);

        }

        // Move the enemy in the appropriate direction
        if (_movingRight)
        {
            enemyRigidbody2D.velocity = new Vector3(moveSpeed, enemyRigidbody2D.velocity.y, 0f);
        }
        else
        {
            enemyRigidbody2D.velocity = new Vector3(-moveSpeed, enemyRigidbody2D.velocity.y, 0f);
        }
    }
}
