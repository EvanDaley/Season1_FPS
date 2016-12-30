using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehavior : MonoBehaviour {

	Transform myTransform;
	Transform playerTransform;

	void Start () 
	{
		myTransform = GetComponent<Transform> ();
		playerTransform = GameObject.Find ("FPSController").transform;
	}
	
	void Update () 
	{
		myTransform.LookAt (playerTransform.position);
	}
}
