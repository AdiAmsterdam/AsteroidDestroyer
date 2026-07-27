using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LowLevelPhysics2D;

public class Weapons : MonoBehaviour
{
    [SerializeField] private float fireRate = 0.5f;
    private float nextFireTime;
    [SerializeField] private Bullet bulletPrefab;

    private float bulletRange = 10f;
    private float whipRange = 3f;
    // Two kinds of weapons: bullets and lasers

    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            bulletPrefab.range = bulletRange;
            ShootGun();
        }

        if (Keyboard.current.shiftKey.isPressed)
        {
            bulletPrefab.range = whipRange;
            ShootEnergyWhip();
        }
    }

    void ShootEnergyWhip()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    void ShootGun()
    {
        if (!(Time.time >= nextFireTime)) return;
        nextFireTime = Time.time + fireRate;
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
