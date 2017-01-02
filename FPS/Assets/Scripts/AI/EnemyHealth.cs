using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int health = 400;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		
	}

	void Damage(int amount)
	{
		int random = Random.Range (0, 100);
		if(random > 92)
			BroadcastMessage ("TakeDamage", SendMessageOptions.DontRequireReceiver);
		if(random > 84 && random < 93)
			BroadcastMessage ("TakeDamage2", SendMessageOptions.DontRequireReceiver);
		
		health -= amount;

		//print (health);

		if (health < 1)
		{
			ScoreKeeper.Instance.AddScore (1000);
			BroadcastMessage ("Die", SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == 9)
		{
			if (health > 0)
			{
				Damage (8);
				ScoreKeeper.Instance.AddScore (10);
			}
		}
	}
}
