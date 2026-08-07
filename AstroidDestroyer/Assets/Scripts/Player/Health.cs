using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

public class Health : MonoBehaviour
{
    private ShipMovement shipMovement;
    private Animator animator;
    private string takeDamageTrigger = "TakeDamage";
    private bool isHurt;
    
    [SerializeField] private AudioClip DamageSound;
    [SerializeField] private AudioClip HealSound;
    
    private int batteryAmount = 3;
    private int chargePerBattery = 4;
    private List<int> batteries;
    [SerializeField] HUD hud;

    private void Awake()
    {
        shipMovement = GetComponent<ShipMovement>();
        animator = GetComponent<Animator>();
        batteries = new List<int>(batteryAmount);
        for (int i = 0; i < batteryAmount; i++)
        {
            batteries.Add(chargePerBattery);
        }
        
        hud.UpdateHealth(batteries);
    }

    private void Update()
    {
        if (Keyboard.current.vKey.wasPressedThisFrame)
        {
            AddHealth();
        }
    }

    public void TakeDamage()//Player takes damage
    {
        if (isHurt) return;
        AudioManager.audioManager.PlaySFX(AudioChannel.Ship, DamageSound);
        for (int i = batteries.Count - 1; i >= 0; i--)
        {
            if (batteries[i] > 0)
            {
                batteries[i]--;
                break;
            }
        }
        hud.UpdateHealth(batteries);
        DisableOnDamage();
        animator.SetTrigger(takeDamageTrigger);
    }

    public void AddHealth() //Adding health
    {
        AudioManager.audioManager.PlaySFX(AudioChannel.Ship, HealSound);
        for (int i = 0; i < batteries.Count; i++)
        {
            if (batteries[i] == 0) return;
            if (batteries[i] < chargePerBattery)
            {
                batteries[i]++;
                break;
            }
        }
        hud.UpdateHealth(batteries);
    }

    public bool IsDead()//Player dies
    {
        foreach (var battery in batteries)
        {
            if (battery > 0) return false;
        }
        return true;
    }

    public void DisableOnDamage()
    {
        isHurt = true;
        shipMovement.BodyCollider.enabled = false;
        shipMovement.MagnetCollider.enabled = false;
    }

    public void HurtAnimationFinished()
    {
        isHurt = false;
        shipMovement.BodyCollider.enabled = true;
        shipMovement.MagnetCollider.enabled = true;
    }

    public int GetActiveBatteryAmount()
    {
        int count = 0;
        for (int i = 0; i < batteries.Count; i++)
        {
            if (batteries[i] == 0) return count;
            count++;
        }
        return count;
    }
}
