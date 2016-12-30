using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxonAudio : MonoBehaviour {

	public AudioClip takeDamage;
	public AudioClip takeDamage2;
	public AudioClip deathSound;
	public AudioClip attackSound;

	public AudioSource audioSource;

	void Start () 
	{
		audioSource = GetComponent<AudioSource> ();
	}

	public void PlayAttackAudio()
	{
		if(!audioSource.isPlaying)
			audioSource.PlayOneShot (attackSound);
	}

	public void Die()
	{
		if (!audioSource.isPlaying)
			audioSource.PlayOneShot (deathSound);
	}

	public void TakeDamage()
	{
		if(!audioSource.isPlaying)
			audioSource.PlayOneShot (takeDamage);
	}

	public void TakeDamage2()
	{
		if(!audioSource.isPlaying)
			audioSource.PlayOneShot (takeDamage2);
	}
}
