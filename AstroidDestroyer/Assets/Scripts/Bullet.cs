using System;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] float range = 10f;
    Vector3 originalPosition;
    private float distance;

    private void Awake()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, originalPosition);
        BulletMovement();
        if (distance > range)
        {
            Destroy(gameObject);
        }
    }

    private void BulletMovement()
    {
        transform.Translate(Vector3.up * (Time.deltaTime * bulletSpeed));
    }
}
