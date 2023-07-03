using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemyScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D enemyRigidbody2D;
    private Collider2D visionCollider2D; // Collider for noticing the player

    private bool _movingRight = true;
    [SerializeField] private float moveSpeed = 10f;
    private float _normalMoveSpeed;

    [SerializeField] private float _changeDirectionCooldown = 7f;
    private float _lastChangeDirection;

    
    void Start()
    {
        visionCollider2D = GetComponentInChildren<BoxCollider2D>();
        _lastChangeDirection = Time.time;
        _normalMoveSpeed = moveSpeed;
    }

    void Update()
    {

        bool timeCondition = Time.time - _lastChangeDirection >= _changeDirectionCooldown;
        if (timeCondition)
        {
            ChangeDirection();
        }

    }

    void FixedUpdate()
    {
        EnemyMovement();
    }

    void ChangeDirection()
    {
        _movingRight = !_movingRight;
        float reverseY = Mathf.Abs(transform.rotation.y) - 180;
        transform.Rotate(0, reverseY, 0);
        _lastChangeDirection = Time.time;
    }

    
    
    void EnemyMovement()
    {
        if (_movingRight)
        {
            enemyRigidbody2D.velocity = new Vector3(moveSpeed, enemyRigidbody2D.velocity.y, 0f);
        }
        else
        {
            enemyRigidbody2D.velocity = new Vector3(-moveSpeed, enemyRigidbody2D.velocity.y, 0f);
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (visionCollider2D.isTrigger && !other.gameObject.CompareTag("Player"))
        {
            ChangeDirection();
        }
        
    }

   
}
