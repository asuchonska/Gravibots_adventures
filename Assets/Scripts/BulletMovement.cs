using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private float _bulletSpeed = 5f;
    [SerializeField] private PolygonCollider2D _bulletCollider2D;
    

    void FixedUpdate()
    {
        // SHOOT BULLET
        transform.Translate(new Vector3(4f,0f,0f) *_bulletSpeed * Time.deltaTime);

        // DESTROY - if certain distance is reached 
        if(transform.position.x > 20f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_bulletCollider2D.isTrigger && other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
