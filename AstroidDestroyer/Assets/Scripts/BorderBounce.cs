using System;
using UnityEngine;

public class BorderBounce : MonoBehaviour
{
    [SerializeField] private bool horizontalWall;
    [SerializeField] private float bounceAmount = 2f;
    private Vector2 originalVelocity;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = other.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
                originalVelocity = playerRb.linearVelocity;
            if (horizontalWall)
            {
                playerRb.AddForce(new Vector2(originalVelocity.x, originalVelocity.y * -bounceAmount));
            }
            else
            {
                playerRb.AddForce(new Vector2(originalVelocity.x * -bounceAmount, originalVelocity.y));
            }
        }
    }
}
