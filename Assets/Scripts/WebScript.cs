using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebScript : MonoBehaviour
{
    private float _webSpeed = 5f;
    [SerializeField] private CircleCollider2D _webCollider2D;
    public Vector2 _spawnPoint;
    public Vector2 _currentLocation;

    [SerializeField] private Vector2 _shotRange = new Vector2(30f,0f);
    // Start is called before the first frame update
    void Start()
    {
        _spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    void FixedUpdate()
    {
        // SHOOT BULLET
        transform.Translate(new Vector3(4f,0f,0f) *_webSpeed * Time.deltaTime);
        _currentLocation = new Vector2(transform.position.x, transform.position.y);

        // DESTROY - if certain distance is reached 
        if((_currentLocation-_spawnPoint).sqrMagnitude > _shotRange.sqrMagnitude)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_webCollider2D.isTrigger && other.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
        if (_webCollider2D.isTrigger && other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<PlayerHealth>().Damage();
        }
    }
    
    
}
