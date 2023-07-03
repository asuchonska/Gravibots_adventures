using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShooting : MonoBehaviour
{
    public Vector2 _playerPosition;
    [SerializeField] private GameObject spiderFirePoint;
    [SerializeField] private GameObject webPrefab;
    private float _shotCooldown = 1f;
    private float _lastShot;
    

    private void ShootWeb(Quaternion webAngle)
    {
        bool cooldownCondition = Time.time - _lastShot >= _shotCooldown;
        if (cooldownCondition)
        {
            Instantiate(webPrefab, spiderFirePoint.transform.position, webAngle);
            _lastShot = Time.time;
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Aiming
            _playerPosition = other.transform.position;
            Vector2 cannonPos2D = new Vector2(transform.position.x, transform.position.y);
            Vector2 lookDir = _playerPosition - cannonPos2D; // Finding a 2D vector from cannon position to player
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 180f; // Finding the right angle in degrees to rotate the cannon
            Quaternion webAngle = Quaternion.Euler(0f, 0f, angle);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            ShootWeb(Quaternion.Euler(0f, 0f, angle-180f));
        }
    }
}


