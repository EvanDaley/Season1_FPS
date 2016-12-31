using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{

	public int health = 100;
	public AudioClip takeDamage;
	public AudioSource source;

	public bool dead = false;

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
		// more to come
	}
}
