using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour {

	public GameObject muzzle;
	public GameObject bulletPrefab;
	public float bulletForce = 400f;
	public AudioClip shotSound;
	public AudioSource audioSource;

	public float fireCooldownInterval;
	private float fireCooldown;

	void Update () 
	{
		if (Input.GetMouseButton (0))
		{
			if (Time.time > fireCooldown)
			{
				GameObject bulletInstance = GameObject.Instantiate (bulletPrefab, muzzle.transform.position, muzzle.transform.rotation) as GameObject;
				Rigidbody bulletInstanceRBody = bulletInstance.GetComponent<Rigidbody> ();

				bulletInstanceRBody.AddForce (muzzle.transform.forward * bulletForce);

				fireCooldown = Time.time + fireCooldownInterval;

				audioSource.PlayOneShot (shotSound);
			}
		}
	}
}
