using UnityEngine;

namespace Player
{
    public class BatteryPickup : MonoBehaviour
    {
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
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
