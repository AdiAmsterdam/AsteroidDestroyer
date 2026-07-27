using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public StartMenu startMenu;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnContinueButtonClick()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void OnQuitButtonClick()
    {
        gameObject.SetActive(false);
        startMenu.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
