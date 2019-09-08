using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
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

	void Update()
	{
		if (Input.GetButtonDown("Pause"))
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

	// Check to see if theres a controller conected or not
	private void CheckInputMethod(bool state)
	{
		if (Input.GetJoystickNames().Length > 0)
			ControllerInstructions.SetActive(state);
		else
			KeyboardInstructions.SetActive(state);
	}
}
