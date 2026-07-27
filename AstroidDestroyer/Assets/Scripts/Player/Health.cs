using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Health : MonoBehaviour
{

    [SerializeField] private int startingHealth = 3;
    private int currentHealth;
    
    [SerializeField] HUD hud;

    private void Awake()
    {
        hud.UpdateHealth(startingHealth);
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage()//Player takes damage
    {
        currentHealth--;
        hud.UpdateHealth(currentHealth);
        if (currentHealth <= 0)Die();
    }

    public void AddHealth()//Adding health
    {
        currentHealth++;
        hud.UpdateHealth(currentHealth);
    }

    void Die()//Player dies
    {
        Destroy(gameObject);
    }

}
