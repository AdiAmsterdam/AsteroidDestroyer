using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI MaxscoreText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void UpdateScore(int score)
    {
        scoreText.text = "SCORE: " + score;
    }

    public void UpdateMaxScore(int score)
    {
        MaxscoreText.text = "MAX SCORE: " + score;
    }

    public void OnLeaveButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void GameOverScreenActive()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
