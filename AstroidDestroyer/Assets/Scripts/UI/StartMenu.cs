using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void OnQuitButtonClick()
    {
        Debug.Log("Quit");
        Application.Quit();
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
