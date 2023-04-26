using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    //Menu States
    public enum MenuStates { Main, Settings };
    public MenuStates currentState;

    //Menu Panel Objects
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject player;

    //Audio Mixer
    public AudioMixer audioMixer;
    public AudioManager audioManager;

    //When script begins
    void Awake()
    {
        currentState = MenuStates.Main;
        DontDestroyOnLoad (player);
        audioManager = FindObjectOfType<AudioManager>();
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
        audioManager.Play("ButtonClick");
    	SceneManager.LoadScene("Game");
        SceneManager.MoveGameObjectToScene(player,  SceneManager.GetSceneByName("Game"));
    }
    
    public void GoToSettingsMenu()
    {
        audioManager.Play("ButtonClick");
    	currentState = MenuStates.Settings;
    }
    
    public void GoToMainMenu()
    {
        audioManager.Play("ButtonClick");
    	currentState = MenuStates.Main;
    }

    public void QuitGame()
    {
        audioManager.Play("ButtonClick");
    	Application.Quit();
    }

    public void SetVolume(float volume) 
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetDayLength()
    {
        //DayNightCycle.dayLengthInSeconds = 600f;
    }

}
