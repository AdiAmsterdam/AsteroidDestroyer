using UnityEngine;

public class LaserSwordCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Laser Sword Hit");
        if (other.CompareTag("Astroid"))
            Destroy(other.transform.root.gameObject);
    }
}
