using System;
using DefaultNamespace;
using UnityEngine;

public class LaserSwordCollider : MonoBehaviour
{
    private Score playerScore;
    [SerializeField] private AudioClip laserSwordHit;

    private void Awake()
    {
        playerScore = GetComponentInParent<Score>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Astroid"))
        {
            playerScore.AddScore(10);
            AudioManager.audioManager.PlaySFX(AudioChannel.LaserSword, laserSwordHit);
            Astroid astroid = other.GetComponent<Astroid>();
            if (astroid != null) astroid.Evaporate();
        }
        
        if (other.CompareTag("Debris"))
        {
            playerScore.AddScore(5);
            AudioManager.audioManager.PlaySFX(AudioChannel.LaserSword, laserSwordHit);
            Debris debris = other.GetComponent<Debris>();
            if (debris != null) debris.Evaporate();
        }
    }
}
