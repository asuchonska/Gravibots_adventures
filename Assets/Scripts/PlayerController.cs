using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    [SerializeField] private Rigidbody2D RB;
    [SerializeField] private Animator _animator; 
    
    // Movement
    [SerializeField] private float _moveSpeed = 10f;
    private float _horizontalInput;
    public bool movingRight = true;
    [SerializeField] private float _jumpStrength = 10f;
    [SerializeField] private BoxCollider2D _feet;
    [SerializeField]private bool isGrounded = false; // To check if the player can jump
    
    // Gravity
    private float _gravityScale; // CZY POTZREBNE???
    public bool gravityIsReversed = false;
    
    
    // Shooting
    [SerializeField] private GameObject _bulletPrefab;
    private float _fireCoolDownTime = 0f;
    private float _nextFireTime = 0.5f;
    
    // Lives
    private int _lives = 5;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void GetMovementInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        if (_horizontalInput > 0 && !movingRight)
        {
            float reverseY = Mathf.Abs(transform.rotation.y) - 180;
            transform.Rotate(0, reverseY, 0);
            movingRight = true;
        } else if (_horizontalInput < 0 && movingRight)
        {
            float reverseY = Mathf.Abs(transform.rotation.y) - 180;
            transform.Rotate(0, reverseY, 0);
            movingRight = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            RB.gravityScale = -RB.gravityScale;
            gravityIsReversed = !gravityIsReversed;
            float reverseX = Mathf.Abs(transform.rotation.x) - 180;
            transform.Rotate(reverseX, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            
        }


    }

    void Jump()
    {
        // Apply the force to the Rigidbody
        float direction = gravityIsReversed ? -1f : 1f;
        RB.AddForce(Vector2.up * _jumpStrength * direction, ForceMode2D.Impulse);
        
    }
    
    private void Movement()
    {
        float walk = Mathf.Abs(_horizontalInput); // To fix walking after rotation
        transform.Translate(Vector3.right * Time.deltaTime * _moveSpeed * walk);
        _animator.SetFloat("speed", walk);

    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && _feet.isTrigger)
        {
            isGrounded = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && _feet.isTrigger)
        {
            isGrounded = false;
        }
    }
}
