using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicGun : MonoBehaviour {

	public GameObject muzzle;
	public GameObject bulletPrefab;
	public float bulletForce = 400f;
	public AudioClip shotSound;
	public AudioClip kickSound;
	public AudioClip reloadingClip;
	public AudioSource audioSource;

	public float fireCooldownInterval;
	private float fireCooldown;

	public GameObject gunPlaceholder;
	public float slideAmount = .3f;
	public float recoilAmount = .5f;

	public float reloadLength = .8f;
	public float reloadCooldown;
	private bool reloading = false;

	public int clipSize = 12;
	public int clipRemaining;

	public Text currentBullets;
	public Text maxBullets;

	void Start()
	{
		clipRemaining = clipSize;
	}

	void Update () 
	{
		ReturnToCenter ();

		if (Time.time > reloadCooldown && reloading == true)
		{
			reloading = false;
			clipRemaining = clipSize;

			ReticleController.Instance.FinishReload ();
		}

		currentBullets.text = clipRemaining.ToString ();
		maxBullets.text = clipSize.ToString ();

		if (Input.GetKey (KeyCode.R) && reloading == false)
		{
			Reload ();
		}

		if (Input.GetMouseButton (0) && reloading == false)
		{
			if (Time.time > fireCooldown)
			{
				if (clipRemaining < 1)
				{
					// we are out of bullets

					// clicking sound
					audioSource.PlayOneShot (kickSound);

					fireCooldown = Time.time + fireCooldownInterval;

				} else
				{
					// we are not out of bullets
					clipRemaining -= 1;
				
					RaycastHit hit;

					Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit);

					float distanceToHit = Vector3.Distance (Camera.main.transform.position, hit.point);
					if (distanceToHit > 3)
					{
						transform.LookAt (hit.point);
					}

					GameObject bulletInstance = GameObject.Instantiate (bulletPrefab, muzzle.transform.position, muzzle.transform.rotation) as GameObject;
					Rigidbody bulletInstanceRBody = bulletInstance.GetComponent<Rigidbody> ();

					bulletInstanceRBody.AddForce (muzzle.transform.forward * bulletForce);

					fireCooldown = Time.time + fireCooldownInterval;

					audioSource.PlayOneShot (shotSound);

					Recoil ();
				}
			}
		}
	}

	void Reload()
	{
		reloadCooldown = Time.time + reloadLength;
		reloading = true;
		audioSource.PlayOneShot (reloadingClip);

		ReticleController.Instance.StartReload ();
	}

	void Recoil()
	{
		transform.position = transform.position + (-1 * transform.forward * recoilAmount);
	}

	void ReturnToCenter()
	{
		transform.position = Vector3.MoveTowards (transform.position, gunPlaceholder.transform.position, slideAmount * Time.deltaTime);
	}
}
