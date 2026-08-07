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
        if (hud) hud.UpdateScore(score);
    }
    
    public void AddScore(int amount)//Adding score
    {
        score += amount;
        hud.UpdateScore(score);
    }
}
