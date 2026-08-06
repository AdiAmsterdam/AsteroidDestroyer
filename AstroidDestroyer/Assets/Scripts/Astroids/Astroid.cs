using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Astroid : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private ParticleSystem explosionPrefab;
    
    private float angle;
    public float speed = 1f;
    private Rigidbody2D rb;
    private float astroidRotation;
    private float astroidScale;
    
    void Start()
    {
        astroidRotation = Random.Range(90f, 500f);
        astroidScale = Random.Range(0.5f, 1.5f);
        //angle = Mathf.Atan2(transform.position.y, transform.position.x);
        angle = Mathf.Atan2(transform.position.y - playerPos.position.y, transform.position.x - playerPos.position.x);
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector3( -Mathf.Cos(angle) * speed,-Mathf.Sin(angle) * speed,0);
    }

    void Update()
    {
        RandomizeAstroidMovement();
    }

    public void Explode()//Destroys the asteroid and create an explosion
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    private void RandomizeAstroidMovement()
    {
        transform.Rotate(0f, 0f, astroidRotation * Time.deltaTime);
        transform.localScale = new Vector3(astroidScale, astroidScale, astroidScale);
    }

   

    
}
