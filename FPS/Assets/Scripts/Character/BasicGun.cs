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

	public GameObject gunPlaceholder;
	public float slideAmount = .3f;
	public float recoilAmount = .5f;

	void Update () 
	{
		ReturnToCenter ();

		if (Input.GetMouseButton (0))
		{
			if (Time.time > fireCooldown)
			{
				GameObject bulletInstance = GameObject.Instantiate (bulletPrefab, muzzle.transform.position, muzzle.transform.rotation) as GameObject;
				Rigidbody bulletInstanceRBody = bulletInstance.GetComponent<Rigidbody> ();

				bulletInstanceRBody.AddForce (muzzle.transform.forward * bulletForce);

				fireCooldown = Time.time + fireCooldownInterval;

				audioSource.PlayOneShot (shotSound);

				Recoil ();
			}
		}
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
