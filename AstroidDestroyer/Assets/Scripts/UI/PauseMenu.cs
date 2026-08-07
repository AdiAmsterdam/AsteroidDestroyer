using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnContinueButtonClick()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void OnQuitButtonClick()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
