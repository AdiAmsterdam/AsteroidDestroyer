using Unity.VisualScripting;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    private float angle;
    public float speed = 1f;
    private Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        angle = Mathf.Atan2(transform.position.y, transform.position.x);
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector3( -Mathf.Cos(angle) * speed,-Mathf.Sin(angle) * speed,0);
    }

    // Update is called once per frame
    void Update()
    {
    }

   

    
}
