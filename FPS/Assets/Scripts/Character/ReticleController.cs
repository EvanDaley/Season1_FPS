using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleController : MonoBehaviour {

	public static ReticleController Instance;

	public Image reticleImage;

	public Sprite rifleDefault;
	public Sprite rifleHit;

	public float resetInterval = .1f;
	private float resetCooldown;

	public bool reloading = false;

	public AudioClip hitSound;
	public AudioSource audioSource;

	void Start () 
	{
		Instance = this;
	}
	
	void Update () 
	{
		if (Time.time > resetCooldown)
		{
			if (reloading == true)
			{
				reticleImage.enabled = false;
			} 
			else
			{
				reticleImage.enabled = true;
				reticleImage.sprite = rifleDefault;
			}
		}
	}

	public void Hit()
	{
		print ("HIT");

		reticleImage.sprite = rifleHit;

		resetCooldown = Time.time + resetInterval;

		audioSource.PlayOneShot (hitSound);
	}

	public void FinishReload()
	{
		reloading = false;
	}

	public void StartReload()
	{
		reloading = true;
	}
}
