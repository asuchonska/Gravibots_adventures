using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingPoint : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    private float _fireCoolDownTime = 0f;
    private float _nextFireTime;
    
    public void FiringBullets()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity, this.transform);
        _nextFireTime = Time.time + _fireCoolDownTime;
    }
    
}
