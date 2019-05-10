﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public GameObject StartMenu;
    public GameObject PauseMenu;
    public GameObject OptionMenu;
    public GameObject Timer;

    public bool IsPaused = true;


	// Use this for initialization
	void Start () {
        Time.timeScale = 0.0f;
        StartMenu.SetActive(true);
        PauseMenu.SetActive(false);
        OptionMenu.SetActive(false);
        Timer.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("escape"))
        {
            PauseGame();
        }

	}

    public void StartGame ()

    {
        IsPaused = false;
        StartMenu.SetActive(false);
        Timer.SetActive(true);
        Time.timeScale = 1.0f;
    }


    private void PauseGame()
    {
        if (IsPaused == true)
        { 
            Time.timeScale = 1.0f;
            PauseMenu.SetActive(false);
            IsPaused = false;
        }
        else
        {
            Time.timeScale = 0.0f;
            PauseMenu.SetActive(true);
            IsPaused = true;
        }

    }

    public void OptionsMenu()
    {
        OptionMenu.SetActive(true);
        StartMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitei");
    }

    public void BackMenu()
    {
        OptionMenu.SetActive(false);
        StartMenu.SetActive(true);
    }

    public void BackFromPause()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Continue()
    {
        PauseGame();
    }
}
