using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuControl : MonoBehaviour {

	public bool isPaused = false;

	public FirstPersonController fps;

	public GameObject Menu;

	void Start () 
	{
		Resume ();
	}
	
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Pause ();
		}
	}

	public void StartGame()
	{
		SceneManager.LoadScene (1);
	}

	public void Quit()
	{
		Application.Quit ();
	}

	public void Resume()
	{
		print ("Resume");

		isPaused = false;

		Time.timeScale = 1;

		fps.m_MouseLook.SetCursorLock (true);

		Menu.SetActive (false);
	}

	public void Pause()
	{
		print ("Paused");

		isPaused = true;

		Time.timeScale = 0;

		fps.m_MouseLook.SetCursorLock (false);

		Menu.SetActive (true);
	}
}
