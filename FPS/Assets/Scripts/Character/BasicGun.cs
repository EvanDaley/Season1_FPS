using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : MonoBehaviour {

	public GameObject muzzle;
	public GameObject bulletPrefab;
	public float bulletForce = 400f;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		if (Input.GetMouseButton (0))
		{
			GameObject bulletInstance = GameObject.Instantiate (bulletPrefab, muzzle.transform.position, Random.rotation) as GameObject;
			Rigidbody bulletInstanceRBody = bulletInstance.GetComponent<Rigidbody> ();

			bulletInstanceRBody.AddForce (muzzle.transform.forward * bulletForce);
		}
	}
}
