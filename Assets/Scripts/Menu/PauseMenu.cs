using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public GameObject PauseMenuPanel;
	public GameObject RestartPanel;
	public GameObject ExitPanel;
	public GameObject GameHUD;

	public void Start()
	{
		Time.timeScale = 1;
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (Time.timeScale == 1)
			{
				Pause();
			}
			else
			{
				Resume();
			}
		}
	}

	void Pause()
	{
		PauseMenuPanel.SetActive(true);
		Time.timeScale = 0;
		Cursor.lockState = CursorLockMode.None;
		GameHUD.SetActive(false);
	}

	void Resume()
	{
		PauseMenuPanel.SetActive(false);
		Time.timeScale = 1;
		Cursor.lockState = CursorLockMode.Locked;
		GameHUD.SetActive(true);
		RestartPanel.SetActive(false);
		ExitPanel.SetActive(false);
	}

	public void ResumeGame()
	{
		Resume();
	}

	public void RestartGame()
	{
		RestartPanel.SetActive(true);
	}

	public void ConfirmRestart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void CancelRestart()
	{
		RestartPanel.SetActive(false);
	}

	public void ExitGame()
	{
		ExitPanel.SetActive(true);
	}

	public void ConfirmExit()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void CancelExit()
	{
		ExitPanel.SetActive(false);
	}
}
