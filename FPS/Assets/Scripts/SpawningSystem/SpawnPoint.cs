using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

	public float cooldown;
	public float spawnInterval = 1f;

	void Start () 
	{
		MeshRenderer renderer = GetComponent<MeshRenderer> ();
		renderer.enabled = false;

		WaveManager.Instance.RegisterSpawnPoint (this);
	}
	
	void Update () 
	{
		
	}

	public bool CheckClear()
	{
		if (Time.time > cooldown)
		{
			return true;
		}

		cooldown = Time.time + spawnInterval;

		return false;
	}


}
