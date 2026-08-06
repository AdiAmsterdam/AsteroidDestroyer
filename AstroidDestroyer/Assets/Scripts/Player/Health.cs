using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class Health : MonoBehaviour
{

    private int batteryAmount = 3;
    private int chargePerBattery = 4;
    private List<int> batteries;
    [SerializeField] HUD hud;

    private void Awake()
    {
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
        for (int i = batteries.Count - 1; i >= 0; i--)
        {
            if (batteries[i] > 0)
            {
                batteries[i]--;
                break;
            }
        }
        hud.UpdateHealth(batteries);
    }

    public void AddHealth() //Adding health
    {
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

}
