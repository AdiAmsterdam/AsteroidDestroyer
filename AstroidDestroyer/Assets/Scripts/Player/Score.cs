using UnityEngine;
using UnityEngine.InputSystem;

public class Score : MonoBehaviour
{
    private int score;
    
    HUD hud;
    
    GameOverMenu gameOverMenu;
    
    private int highScore;
    
    
    private const string HighScoreKey = "HighScore";

    void Awake()
    {
        hud = FindFirstObjectByType<HUD>();
        gameOverMenu = FindObjectOfType<GameOverMenu>();
        score = 0;
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if (hud) hud.UpdateScore(score);
        if (gameOverMenu)
        {
            gameOverMenu.UpdateScore(score);
            gameOverMenu.UpdateMaxScore(highScore);
        }
    }
    
    public void AddScore(int amount)//Adding score
    {
        score += amount;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(HighScoreKey, highScore);
            PlayerPrefs.Save(); 
        }

        if (hud) hud.UpdateScore(score);
        if (gameOverMenu)
        {
            gameOverMenu.UpdateScore(score);
            gameOverMenu.UpdateMaxScore(highScore);
        }
    }

    public int Score1
    {
        get => score;
    }
}
