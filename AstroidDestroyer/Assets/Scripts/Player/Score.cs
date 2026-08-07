using UnityEngine;
using UnityEngine.InputSystem;

public class Score : MonoBehaviour
{
    private int score;
    
    HUD hud;

    void Awake()
    {
        hud = FindFirstObjectByType<HUD>();
        score = 0;
        hud.UpdateScore(score);
    }
    
    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            AddScore(100);
        }
    }
    
    public void AddScore(int amount)//Adding score
    {
        score += amount;
        hud.UpdateScore(score);
    }
}
