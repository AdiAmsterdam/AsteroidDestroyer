using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LowLevelPhysics2D;

public class Weapons : MonoBehaviour
{
    Bullet bullet;
    // Two kinds of weapons: bullets and lasers
    void Awake()
    {
    bullet = GetComponent<Bullet>();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    void ShootGun()
    {
        //shoots a gun
    }
}
