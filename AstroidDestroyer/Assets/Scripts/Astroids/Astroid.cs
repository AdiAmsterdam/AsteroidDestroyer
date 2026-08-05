using Unity.VisualScripting;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionPrefab;
    
    private float angle;
    public float speed = 1f;
    private Rigidbody2D rb;
    
    void Start()
    {
        angle = Mathf.Atan2(transform.position.y, transform.position.x);
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector3( -Mathf.Cos(angle) * speed,-Mathf.Sin(angle) * speed,0);
    }

    public void Explode()//Destroys the asteroid and create an explosion
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

   

    
}
