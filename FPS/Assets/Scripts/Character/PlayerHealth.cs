using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int health = 100;
	public AudioClip takeDamage;
	public AudioSource source;

	public void TakeDamage(int dmg)
	{
		health -= dmg;
		source.PlayOneShot (takeDamage);
		print (health);
	}
}
