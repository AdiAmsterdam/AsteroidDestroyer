using UnityEngine;

public class LaserSwordCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (swordState == SwordState.Closed) return;
        Debug.Log("Laser Sword Hit");
        if (other.CompareTag("Astroid"))
            Destroy(other.transform.root.gameObject);
    }
}
