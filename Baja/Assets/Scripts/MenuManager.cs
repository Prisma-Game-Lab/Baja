using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Luminosity.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
	public GameObject StartMenu;
	public GameObject PauseMenu;
	public GameObject OptionMenu;
	public GameObject Timer;
	public GameObject WinPanel;
	public GameObject ControllerInstructions;
	public GameObject KeyboardInstructions;
	public GameObject HUD;
	[HideInInspector]
	public bool IsPaused = true;
	public static bool AfterCountdown = false;

    public GameObject FirstSelectedOptionOnStartMenu, FirstSelectedOptionOnPauseMenu, FirstSelectedOptionOnOptionsMenu, FirstSelectedOptionOnResultMenu, 
    FirstSelectedOptionOnControllerInstructionsMenu, FirstSelectedOptionOnKeyboardInstructionsMenu; 


	// Use this for initialization
    void Awake(){
        instance = this;
    }
	void Start()
	{
		Time.timeScale = 0.0f;
		StartMenu.SetActive(true);
		PauseMenu.SetActive(false);
		OptionMenu.SetActive(false);
		WinPanel.SetActive(false);
		Timer.SetActive(false);
		Countdown.laptime = -0.02f;
	}
	
	// Update is called once per frame
	void Update () {
        if(InputManager.GetButtonDown("Pause"))
        {
            PauseGame();
        }
	}

	public void StartGame()
	{
		//TutorialPanel.SetActive(false);
		CheckInputMethod(false);
		HUD.SetActive(true);
		IsPaused = false;
		Timer.SetActive(true);
		Time.timeScale = 1.0f;
		Countdown.laptime = -0.02f;
		AfterCountdown = true;
	}

	public void OpenInstructions()
	{
		StartMenu.SetActive(false);
		WinPanel.SetActive(false);
		CheckInputMethod(true);
		//TutorialPanel.SetActive(true);
	}


	private void PauseGame()
	{
		if (IsPaused == true)
		{
			Time.timeScale = 1.0f;
			PauseMenu.SetActive(false);
			IsPaused = false;
		}
		else if (!WinPanel.activeInHierarchy && !OptionMenu.activeInHierarchy && !StartMenu.activeInHierarchy)
		{
			Time.timeScale = 0.0f;
			PauseMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(FirstSelectedOptionOnPauseMenu);
			IsPaused = true;
		}
	}

	public void OptionsMenu()
	{
		OptionMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(FirstSelectedOptionOnOptionsMenu);
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
        EventSystem.current.SetSelectedGameObject(FirstSelectedOptionOnStartMenu);
	}

	public void BackFromPause()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Continue()
	{
		PauseGame();
	}

	// Check to see if theres a controller conected or not
	private void CheckInputMethod(bool state)
	{
		if (Input.GetJoystickNames().Length > 0){
			ControllerInstructions.SetActive(state);
            EventSystem.current.SetSelectedGameObject(FirstSelectedOptionOnControllerInstructionsMenu);
        }
		else {
			KeyboardInstructions.SetActive(state);
            EventSystem.current.SetSelectedGameObject(FirstSelectedOptionOnKeyboardInstructionsMenu);
        }
	}
}
