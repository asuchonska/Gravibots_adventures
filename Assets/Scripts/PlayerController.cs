using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    [SerializeField] private Rigidbody2D RB;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _firePoint;
    
    // Movement
    private float _walk;
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
        // Updating animator component
        _animator.SetFloat("speed", _walk);
        _animator.SetBool("isGrounded", isGrounded);
        
        
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
            _animator.SetTrigger("gravityChange");
            RB.gravityScale = -RB.gravityScale;
            gravityIsReversed = !gravityIsReversed;
            float reverseX = Mathf.Abs(transform.rotation.x) - 180;
            transform.Rotate(reverseX, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            FiringBullets();
            _animator.SetTrigger("shooting");
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
        _walk = Mathf.Abs(_horizontalInput); // To fix walking after rotation
        transform.Translate(Vector3.right * Time.deltaTime * _moveSpeed * _walk);

    }

    private void FiringBullets()
    {
        Quaternion bulletRotation = Quaternion.Euler(0f, 0f, 180f);
        if (movingRight)
        {
            // Instantiate bullet without rotation change
            Instantiate(_bulletPrefab, _firePoint.transform.position, Quaternion.identity);
        }
        else
        {
            // Instantiate bullet with rotation change (180 degrees on z axis)
            Instantiate(_bulletPrefab, _firePoint.transform.position, bulletRotation);
        }
        _nextFireTime = Time.time + _fireCoolDownTime;
        
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
