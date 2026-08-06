using System;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] float bulletRotation = 600f;
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
        BulletMovement();
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, originalPosition);
        RotateBullet();
        if (distance > range)
        {
            Destroy(gameObject);
        }
    }

    private void BulletMovement()
    {
        rb.linearVelocity = (Vector2)transform.up * bulletSpeed + shipVelocity;
    }

    private void RotateBullet()
    {
        transform.Rotate(0f, 0f, bulletRotation * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Astroid"))
        {
            Debug.Log("Bullet Hit");
            Astroid astroid = collider2D.GetComponent<Astroid>();
            if (astroid != null) astroid.Explode();
            Destroy(gameObject);
        }
    }
}
