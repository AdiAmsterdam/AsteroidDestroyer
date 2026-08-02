using System;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    public float range;
    Vector3 originalPosition;
    private float distance;
    private Rigidbody2D rb;


    private void Awake()
    {
        originalPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * bulletSpeed;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, originalPosition);
        //BulletMovement();
        if (distance > range)
        {
            Destroy(gameObject);
        }
    }

    private void BulletMovement()
    {
        rb.linearVelocity = transform.up * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Astroid"))
        {
            
            Destroy(collider2D.gameObject);
            Destroy(gameObject);
        }
    }
}
