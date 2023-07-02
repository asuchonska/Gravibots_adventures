using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private float _bulletSpeed = 5f;
    [SerializeField] private PolygonCollider2D _bulletCollider2D;
    public float _spawnPoint;

    [SerializeField] private float _shotRange = 30f;

    void Start()
    {
        _spawnPoint = transform.position.x;
    }

    void FixedUpdate()
    {
        // SHOOT BULLET
        transform.Translate(new Vector3(4f,0f,0f) *_bulletSpeed * Time.deltaTime);
        float distance = Mathf.Abs(transform.position.x - _spawnPoint);

        // DESTROY - if certain distance is reached 
        if(distance > _shotRange)
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
