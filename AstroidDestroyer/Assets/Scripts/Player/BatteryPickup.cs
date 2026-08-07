using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class BatteryPickup : MonoBehaviour
    {
        private float batteryRotation;

        private void Awake()
        {
            batteryRotation = Random.Range(-90f, -150f);
        }

        private void Update()
        {
            transform.Rotate(0f, 0f, batteryRotation * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other is PolygonCollider2D && other.CompareTag("Player"))
            {
                Health playerHealth = other.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.AddHealth();
                    Destroy(gameObject);
                }
            }
        }
    }
}
