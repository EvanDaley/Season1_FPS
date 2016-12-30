﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxonMovement : MonoBehaviour {

	Transform playerTransform;
	Transform axonTransform;

	public float stoppingDistance = 1f;
	public float moveSpeed = 2f;
	private float timer1;

	private Animator axonAnimator;

	private bool dead = false;

	void Start () 
	{
		playerTransform = GameObject.Find ("PlayerFeet").transform;
		axonTransform = GetComponent<Transform> ();
		timer1 = Time.time;

		axonAnimator = GetComponent<Animator> ();
	}
	
	void Update () 
	{
		if (dead == true)
		{
			return;
		}

		axonTransform.LookAt (playerTransform.position);

		float distanceToPlayer = Vector3.Distance (axonTransform.position, playerTransform.position);

		if (distanceToPlayer > stoppingDistance)
		{
			Move (playerTransform.position);
		} else
		{
			Attack ();
		}
	}

	void Move(Vector3 target)
	{
		if (Time.time < timer1 + 1.33f)
		{
			return;
		}

		//print ("Moving");

		axonTransform.position = Vector3.MoveTowards (axonTransform.position, playerTransform.position, moveSpeed * Time.deltaTime);
		axonAnimator.SetBool ("attacking", false);
	}

	void Attack()
	{
		//print ("Attacking");

		axonAnimator.SetBool ("attacking", true);

		BroadcastMessage ("PlayAttackAudio", SendMessageOptions.DontRequireReceiver);
	}

	public void Die()
	{
		print ("dying");

		dead = true;

		axonAnimator.SetBool ("dead", true);

		Rigidbody rbody = GetComponent<Rigidbody> ();
		Destroy (rbody);

		//transform.rotation = Quaternion.identity;
	}
}
