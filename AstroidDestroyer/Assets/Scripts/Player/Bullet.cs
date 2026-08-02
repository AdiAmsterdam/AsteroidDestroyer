using System;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    public float range = 100f;
    Vector2 originalPosition;
    private float distance;
    private Rigidbody2D rb;
    
    public Vector2 shipVelocity;


    void Awake()
    {
        originalPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        shipVelocity = Vector2.zero;
    }

    private void Start()
    { 
        rb.linearVelocity = (Vector2)transform.up * bulletSpeed + shipVelocity;
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, originalPosition);
        BulletMovement();
        if (distance > range)
        {
            Destroy(gameObject);
        }
    }

    private void BulletMovement()
    {
        rb.linearVelocity = (Vector2)transform.up * bulletSpeed + shipVelocity;
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Astroid"))
        {
            Debug.Log("Bullet Hit");
            Destroy(collider2D.gameObject);
            Destroy(gameObject);
        }
    }
}
