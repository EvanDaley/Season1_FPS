using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour 
{
	public int health = 100;
	public AudioClip takeDamage;
	public AudioSource source;

	public bool dead = false;
	public Text deathText;

	public GameObject panelBlackout;

	public void TakeDamage(int dmg)
	{
		health -= dmg;
		source.PlayOneShot (takeDamage);
		print (health);

		if (health < 0)
		{
			if(dead == false)
				Die ();

			dead = true;
		}
	}

	public void Die()
	{
		deathText.text = "CRUSHED";

		panelBlackout.SetActive (true);

		Invoke ("Restart", .41f);

		MenuControl.Instance.Pause ();
	}

	void Restart()
	{
		SceneManager.LoadScene (0);
	}
}
