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
    
    public void TakeDamage()//Player takes damage
    {
        currentHealth--;
        hud.UpdateHealth(currentHealth);
    }

    public void AddHealth()//Adding health
    {
        currentHealth++;
        hud.UpdateHealth(currentHealth);
    }

    public bool IsDead()//Player dies
    {
        return currentHealth <= 0;
    }

}
