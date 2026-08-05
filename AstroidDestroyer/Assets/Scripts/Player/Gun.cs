using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Gun : MonoBehaviour
    {
        private ShipMovement shipMovement;
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] AudioClip gunSound;
        
        [SerializeField] private float fireRate = 1f;
        private float gunTimer;
        
        private float gunRange = 10f;

        void Awake()
        {
            shipMovement = GetComponentInParent<ShipMovement>();
        }

        void Update()
        {
            if (Keyboard.current.spaceKey.isPressed)
            {
                ShootGun();
            }
        }

        void ShootGun()
        {
            if (!(Time.time >= gunTimer)) return;
            gunTimer = Time.time + fireRate;
            Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.range = gunRange;
            bullet.shipVelocity = shipMovement.rb.linearVelocity;
            AudioManager.audioManager.PlaySFX(AudioChannel.Gun, gunSound);
        }
    }
}