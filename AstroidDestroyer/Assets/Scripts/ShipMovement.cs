using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{

    public float speed = 2f;

    public float rotationSpeed = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            transform.Translate(Vector3.up * (Time.deltaTime * speed));
        }

        if (Keyboard.current.dKey.isPressed)
        {
            transform.Rotate(Vector3.back, Time.deltaTime * rotationSpeed);
        }

        if (Keyboard.current.aKey.isPressed)
        {
            transform.Rotate(Vector3.forward * (Time.deltaTime * rotationSpeed));
        }
    }
}
