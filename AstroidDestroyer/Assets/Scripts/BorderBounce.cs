using System;
using System.Collections;
using UnityEngine;

public class BorderBounce : MonoBehaviour
{
    [SerializeField] private ShipMovement shipMovement;
    [SerializeField] private bool horizontalWall;
    [SerializeField] private float bounceAmount = 2.5f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shipMovement.hitBorder = true;
            shipMovement.StopMovement();
            Rigidbody2D playerRb = other.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                if (horizontalWall)
                {
                    playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, playerRb.linearVelocity.y * -bounceAmount);
                }
                else
                {
                    playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x * -bounceAmount, playerRb.linearVelocity.y);
                }
            }
            StartCoroutine(ResetHitBorder());
        }
    }

    private IEnumerator ResetHitBorder()
    {
        yield return new WaitForSeconds(1f);
        shipMovement.hitBorder = false;
    }
}
