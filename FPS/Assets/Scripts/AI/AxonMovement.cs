using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxonMovement : MonoBehaviour {

	Transform playerTransform;
	Transform axonTransform;

	public float stoppingDistance = 1f;
	public float moveSpeed = 2f;
	private float timer1;

	void Start () 
	{
		playerTransform = GameObject.Find ("PlayerFeet").transform;
		axonTransform = GetComponent<Transform> ();
		timer1 = Time.time;
	}
	
	void Update () 
	{
		axonTransform.LookAt (playerTransform.position);

		float distanceToPlayer = Vector3.Distance (axonTransform.position, playerTransform.position);

		if (distanceToPlayer > stoppingDistance)
		{
			Move (playerTransform.position);
		} else
		{
			Stop ();
		}
	}

	void Move(Vector3 target)
	{
		if (Time.time < timer1 + 1.33f)
		{
			return;
		}

		print ("Moving");

		axonTransform.position = Vector3.MoveTowards (axonTransform.position, playerTransform.position, moveSpeed * Time.deltaTime);
	}

	void Stop()
	{
		print ("Stopped");
	}
}
