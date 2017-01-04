using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AxonMovement : MonoBehaviour {

	Transform playerTransform;
	Transform axonTransform;

	public float stoppingDistance = 1f;
	public float moveSpeed = 2f;
	private float timer1;

	private Animator axonAnimator;

	private bool dead = false;

	public float calculateInterval;
	private float calculateCooldown;

	public NavMeshAgent navMeshAgent;

	void Start () 
	{
		GameObject player = GameObject.Find ("PlayerFeet");

		if(player != null)
			playerTransform = player.transform;

		axonTransform = GetComponent<Transform> ();
		timer1 = Time.time;

		axonAnimator = GetComponent<Animator> ();
	}
	
	void Update () 
	{
		if (dead == true || Time.timeScale == 0)
		{
			return;
		}

		if (playerTransform != null)
		{
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

	}

	void Move(Vector3 target)
	{
		if (Time.time < timer1 + 1.33f)
		{
			return;
		}

		//print ("Moving");

		//axonTransform.position = Vector3.MoveTowards (axonTransform.position, playerTransform.position, moveSpeed * Time.deltaTime);

		navMeshAgent.SetDestination (playerTransform.position);

		axonAnimator.SetBool ("attacking", false);
	}

	void Attack()
	{
		//print ("Attacking");

		axonAnimator.SetBool ("attacking", true);

		BroadcastMessage ("PlayAttackAudio", SendMessageOptions.DontRequireReceiver);

		if (Time.time > calculateCooldown)
		{
			CalculateHit ();
			calculateCooldown = Time.time + calculateInterval;
		}
	}

	void CalculateHit()
	{
		float distanceToPlayer = Vector3.Distance (playerTransform.position, axonTransform.position);
		if (distanceToPlayer < 4)
		{
			print ("We hit the player");

			PlayerHealth playerHealth = playerTransform.parent.gameObject.GetComponent<PlayerHealth> ();
			if (playerHealth != null)
			{
				print ("Found player health");
				playerHealth.TakeDamage (110);
			}
		}
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
