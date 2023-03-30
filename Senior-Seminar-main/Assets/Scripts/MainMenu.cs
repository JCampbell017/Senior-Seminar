using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //Menu States
    public enum MenuStates { Main, Settings };
    public MenuStates currentState;

    //Menu Panel Objects
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject player;

    //When script begins
    void Awake()
    {
        currentState = MenuStates.Main;
        DontDestroyOnLoad (player);
    }

    void Update()
    {
        if (currentState == MenuStates.Main) 
        {
            mainMenu.SetActive(true);
            settingsMenu.SetActive(false);
        }
        else if (currentState == MenuStates.Settings)
        {
            mainMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }
    }

    public void PlayGame() 
    {
    	SceneManager.LoadScene("Game");
        SceneManager.MoveGameObjectToScene(player,  SceneManager.GetSceneByName("Game"));
    }
    
    public void GoToSettingsMenu()
    {
    	currentState = MenuStates.Settings;
    }
    
    public void GoToMainMenu()
    {
    	currentState = MenuStates.Main;
    }

    public void QuitGame()
    {
    	Application.Quit();
    }
}
