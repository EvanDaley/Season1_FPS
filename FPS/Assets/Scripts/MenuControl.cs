using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuControl : MonoBehaviour {

	public bool isPaused = false;

	public FirstPersonController fps;

	public GameObject Menu;
	public GameObject reticle;

	public static MenuControl Instance;

	void Start () 
	{
		Instance = this;
		Resume ();
	}
	
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Pause ();
		}

		if (SceneManager.GetActiveScene ().buildIndex == 0)
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
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
		//print ("Resume");

		isPaused = false;

		Time.timeScale = 1;

		if(fps != null)
			fps.m_MouseLook.SetCursorLock (true);

		if(Menu != null)
			Menu.SetActive (false);

		if(reticle != null)
			reticle.SetActive (true);
	}

	public void Pause()
	{
		//print ("Paused");

		isPaused = true;

		Time.timeScale = 0;

		if(fps != null)
			fps.m_MouseLook.SetCursorLock (false);

		if(Menu != null)
			Menu.SetActive (true);

		if(reticle != null)
			reticle.SetActive (false);
	}
}
