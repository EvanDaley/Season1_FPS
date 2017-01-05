using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int health = 400;
	public GameObject bloodSplatter;

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
			DieNow ();	
		}
	}

	void DieNow()
	{
		ScoreKeeper.Instance.AddScore (1000);
		BroadcastMessage ("Die", SendMessageOptions.DontRequireReceiver);
		WaveManager.Instance.SignalDeath (this.gameObject);
		Invoke ("DestroyGameObject", 10f);
	}

	void DestroyGameObject()
	{
		Destroy (gameObject);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == 9)
		{
			Destroy (collision.gameObject);
			ReticleController.Instance.Hit ();

			GameObject.Instantiate(bloodSplatter, collision.contacts[0].point, Quaternion.identity);

			if (health > 0)
			{
				Damage (8);
				ScoreKeeper.Instance.AddScore (10);
			}
		}
	}
}
