using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private LogicScript _logic;
    private int _lives = 5; // Lives
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private Animator _animator;

    void Start()
    {
        _logic = GameObject.FindGameObjectWithTag("GameController").GetComponent<LogicScript>();
        _uiManager.UpdateLives(_lives);
    }
    
    
    // Update is called once per frame
    void Update()
    {
       
    }
    
    
    public void Damage()
    {
        _lives --;
        _uiManager.UpdateLives(_lives);
        
        Debug.Log("Damage" + _lives);

        if (_lives == 0)
        {
            // GameController.GameOver();
            Debug.Log("Death");
            _logic.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("DamagePoint"))
        {
            Damage();
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Jest olej ");
            _animator.SetTrigger("Motorol"); 
            _logic.TheEnd();
        }
    }
}



