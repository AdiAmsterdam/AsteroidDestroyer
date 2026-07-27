using UnityEngine;
using UnityEngine.InputSystem;

public class Score : MonoBehaviour
{
    private Health health;
    private int score;
    private int scoreRequiredToHpUp = 1000;
    
    [SerializeField] HUD hud;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        score = 0;
        hud.UpdateScore(score);
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            AddScore(100);
        }
    }
    
    void AddScore(int amount)//Adding score
    {
        score += amount;
        if (score >= scoreRequiredToHpUp)
        {
            score = scoreRequiredToHpUp - score;
            health.AddHealth();
        }
        hud.UpdateScore(score);
    }
}
