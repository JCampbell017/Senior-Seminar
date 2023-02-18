using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() 
    {
    	SceneManager.LoadScene("Demo1Scene");
    }
    
    public void GoToSettingsMenu()
    {
    	SceneManager.LoadScene("SettingsMenu");
    }
    
    public void QuitGame()
    {
    	Application.Quit();
    }
    
    public void GoToMainMenu()
    {
    	SceneManager.LoadScene("MainMenu");
    }
}
