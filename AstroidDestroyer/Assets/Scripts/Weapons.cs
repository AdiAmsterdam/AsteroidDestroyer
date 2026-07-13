using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LowLevelPhysics2D;

public class Weapons : MonoBehaviour
{
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] Bullet bulletPrefab;
    // Two kinds of weapons: bullets and lasers

    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            ShootGun();
        }

        if (Keyboard.current.shiftKey.isPressed)
        {
            ShootEnergyWhip();
        }
    }

    void ShootEnergyWhip()
    { 
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    IEnumerable<WaitForSeconds> ShootGun()//Doesnt work
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.5f);
    }
}
