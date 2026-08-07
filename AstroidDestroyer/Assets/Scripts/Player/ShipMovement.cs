using System.Collections;
using DefaultNamespace;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    
    [SerializeField] private ParticleSystem explosionPrefab;
    [SerializeField] private Transform[] explosionPoints = new Transform[5];
    
    [SerializeField] ParticleSystem engineParticles;
    [SerializeField] ParticleSystem dashParticles;

    public float maxPullForce = 10f;

    public float magnetRadius;

    public Collider2D MagnetCollider;
    public Collider2D BodyCollider;

    private Health health;

    private EnergySystem energySystem;

    [SerializeField] private AudioClip engineSound;
    [SerializeField] private AudioClip explosionSound;

    public float acceleration = 2f;
    public float maxSpeed = 5f;
    public float dashSpeed = 7f;
    public float dashEnergyDrain = 30f;
    private bool thrust;
    private bool dash;
    private float rotation;
    private bool isMoving;
    public bool hitBorder;

    public Rigidbody2D rb { get; private set; }

    public float rotationSpeed = 100f;

    public PauseMenu pauseMenu;

    private void Awake()
    {
        hitBorder = false;
        energySystem = GetComponent<EnergySystem>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Time.timeScale = 0;
        health = GetComponent<Health>();
        magnetRadius = MagnetCollider.bounds.extents.magnitude;
    }


    void Update()
    {
        if(health.IsDead()) return;
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            pauseMenu.PauseGame();
        }

        if (!hitBorder)
        {
            ReadInput();
            HandleThrustSound();
            EngineParticlesControl();
        }

    }

    void FixedUpdate()
    {
        if (hitBorder) return;
        if(health.IsDead()) return;
        MoveShip();
    }

    private void ReadInput()
    {
        thrust = Keyboard.current.wKey.isPressed;
        dash = Keyboard.current.shiftKey.isPressed;

        rotation = 0f;

        if (Keyboard.current.aKey.isPressed)
            rotation = 1f;
        else if (Keyboard.current.dKey.isPressed)
            rotation = -1f;
    }

    private void MoveShip()
    {
        if (thrust)
        {
            rb.linearVelocity += (Vector2)transform.up * (acceleration * Time.fixedDeltaTime);
            rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
        }

        if (rotation < 0)
        {
            rb.angularVelocity = -rotationSpeed;
        }
        else if (rotation > 0)
        {
            rb.angularVelocity = rotationSpeed;
        }
        else
        {
            rb.angularVelocity = 0f;
        }

        if (dash)
        {
            if (energySystem.TrySpendEnergy(dashEnergyDrain * Time.fixedDeltaTime))
            {
                rb.linearVelocity = (Vector2)transform.up * dashSpeed;
            }
        }
    }

    private void HandleThrustSound()
    {
        isMoving = thrust || dash;
        if (isMoving)
        {
            AudioManager.audioManager.PlayEngineSound(engineSound);
        }
        else AudioManager.audioManager.StopEngineSound();
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Astroid"))
        {
            //Debug.Log("Astroid Enter");
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
                    Astroid astroid = collider2D.GetComponent<Astroid>();
                    if (astroid != null) astroid.Explode();
                    if(health.IsDead()) ExplodeShip();
                }
            }
        }
    }

    private void EngineParticlesControl()//Emits the Particles of the engine
    {
        if (thrust)
        {
            if (!engineParticles.isPlaying)
                engineParticles.Play();
        }
        else
        {
            if (engineParticles.isPlaying)
                engineParticles.Stop();
        }
        
        if (dash)
        {
            if (!dashParticles.isPlaying)
                dashParticles.Play();
        }
        else
        {
            if (dashParticles.isPlaying)
                dashParticles.Stop();
        }
    }
    
    private void ExplodeShip()//Initiates the explosion sequence
    {
        StartCoroutine(ExplosionSequence());
    }
    
    IEnumerator ExplosionSequence()//Destroys the ship and create an explosion
    {
        MagnetCollider.enabled = false;
        BodyCollider.enabled = false;
        foreach (Transform point in explosionPoints)
        {
            Instantiate(explosionPrefab, point.position, Quaternion.identity);
            AudioManager.audioManager.PlaySFX(AudioChannel.Ship, explosionSound);
            yield return new WaitForSeconds(0.3f);
        }
        Destroy(gameObject);
    }
    
    public void StopMovement()
    {
        thrust = false;
        dash = false;
        AudioManager.audioManager.StopEngineSound();
        if(engineParticles.isPlaying) engineParticles.Stop();
        if(dashParticles.isPlaying) dashParticles.Stop();
    }
}

