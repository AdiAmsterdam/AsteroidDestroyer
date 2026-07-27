using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{

    public float speed = 2f;

    public float rotationSpeed = 100f;

    public PauseMenu pauseMenu;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            pauseMenu.PauseGame();
        }

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

