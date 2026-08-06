using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public StartMenu startMenu;

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
        startMenu.gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
