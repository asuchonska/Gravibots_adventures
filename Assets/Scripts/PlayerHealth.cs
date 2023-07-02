using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Lives
    private int _lives = 5;
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private UIManager _uiManager;

    void Start()
    {
        _uiManager.UpdateLives(_lives);
    }
    
    
    // Update is called once per frame
    void Update()
    {
       
    }

    private void PlayerDeath()
    {
        Debug.Log("Player Died!!!");
    }
    
    private void Damage()
    {
        _lives --;
        _uiManager.UpdateLives(_lives);
        
        Debug.Log("Damage" + _lives);

        if (_lives == 0)
        {
            Debug.Log("Death");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("DamagePoint"))
        {
            Damage();
        }
    }
}


