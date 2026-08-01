using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{

    public float speed = 2f;

    public float rotationSpeed = 100f;

    public PauseMenu pauseMenu;
    
    public float maxPullForce = 10f;

    public float magnetRadius;

    public Collider2D MagnetCollider;
    public Collider2D BodyCollider;

    private Health health;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0;
        health = GetComponent<Health>();
        magnetRadius = MagnetCollider.bounds.extents.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            pauseMenu.PauseGame();
        }

        HandleMovement();
    }

    private void HandleMovement()
    {

        if (Keyboard.current.wKey.isPressed)
        {
            transform.Translate(Vector3.up * (Time.deltaTime * speed));
        }

        if (Keyboard.current.dKey.isPressed)
        {
            transform.Rotate(Vector3.back, Time.deltaTime * rotationSpeed);
        }

        if (Keyboard.current.aKey.isPressed)
        {
            transform.Rotate(Vector3.forward * (Time.deltaTime * rotationSpeed));
        }
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Astroid"))
        {
            Debug.Log("Astroid Enter");
            Rigidbody2D rb = collider2D.GetComponent<Rigidbody2D>();
            
            if (rb != null)
            {
                if (MagnetCollider.IsTouching(collider2D))
                {
                    Vector3 direction = transform.position - collider2D.transform.position;
                    float distance = direction.magnitude;

                    if (distance < 0.1f) return;

                    float closeness = 1f - (distance / magnetRadius);
                    closeness = Mathf.Clamp01(closeness);

                    float forceMultiplier = closeness;

                    float finalForce = maxPullForce * forceMultiplier;
                    rb.linearVelocity = direction.normalized * finalForce;
                }

                if (BodyCollider.IsTouching(collider2D))
                {
                    health.TakeDamage();
                    Destroy(collider2D.gameObject);
                }
            }
        }
    }
}

