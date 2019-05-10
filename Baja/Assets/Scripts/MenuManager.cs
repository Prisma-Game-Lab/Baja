using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public GameObject StartMenu;
    public GameObject PauseMenu;

    public bool IsPaused = true;


	// Use this for initialization
	void Start () {
        Time.timeScale = 0.0f;
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
        Time.timeScale = 1.0f;
    }


    public void PauseGame()
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
}
