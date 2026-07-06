using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.LowLevelPhysics2D;

public class Weapons : MonoBehaviour
{

    public float bulletSpeed = 5f;
    public float laserSpeed = 10f;
    
    private SpriteRenderer bulletSprite;
    // Two kinds of weapons: bullets and lasers
    void Awake()
    {

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
        //Shoot bullet from the gun
        return;
    }

    void ShootLaser()
    {
        //shoots a laser
    }
}
