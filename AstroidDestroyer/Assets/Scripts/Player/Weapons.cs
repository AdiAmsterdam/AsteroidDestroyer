using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LowLevelPhysics2D;

public class Weapons : MonoBehaviour
{
    private ShipMovement shipMovement;
    private EnergySystem energySystem;
    
    
    [SerializeField] private float whipEnergyDrain = 15f;
    [SerializeField] float whipFireRate = 0.01f;
    private float whipTimer;
    
    [SerializeField] AudioClip gunSound;
    [SerializeField] AudioClip whipSound;
    //start sound = plays when starting to shoot
    //loop sound = plays on loop when start sound is over
    //end sound = plays when loop sound ends
    //recharge = plays when recharging
    
    [SerializeField] private float fireRate = 0.5f;
    private float gunTimer;
    [SerializeField] private Bullet bulletPrefab;

    private float gunRange = 10f;
    private float whipRange = 3f;
    
    // Two kinds of weapons: bullets and lasers


    void Awake()
    {
        energySystem = GetComponentInParent<EnergySystem>();
        shipMovement = GetComponentInParent<ShipMovement>();
    }
    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            ShootGun();
        }

        if (Keyboard.current.ctrlKey.isPressed)
        {
            ShootEnergyWhip();
        }
    }

    void ShootEnergyWhip()
    {
        if (!energySystem.TrySpendEnergy(whipEnergyDrain * Time.deltaTime))
        {
            whipTimer = 0;
            return;
        }
        whipTimer -= Time.deltaTime;
        if (whipTimer <= 0f)
        {
            whipTimer = whipFireRate;

            Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.range = whipRange;
            bullet.shipVelocity = shipMovement.rb.linearVelocity;
        }
    }

    void ShootGun()
    {
        if (!(Time.time >= gunTimer)) return;
        gunTimer = Time.time + fireRate;
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.range = gunRange;
        bullet.shipVelocity = shipMovement.rb.linearVelocity;
        AudioManager.audioManager.PlaySFX(gunSound);
    }
    /*
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
        SpawnBullet();
    }

    void ShootGun()
    {
        if (!(Time.time >= nextFireTime)) return;
        nextFireTime = Time.time + fireRate;
        SpawnBullet();
    }
    
    void SpawnBullet()
    {
       // Bullet b = 
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        //b.gameObject.SetActive(true);
    }
    */
}
