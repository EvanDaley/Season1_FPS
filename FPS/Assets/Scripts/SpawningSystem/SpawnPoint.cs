using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

	void Start () 
	{
		MeshRenderer renderer = GetComponent<MeshRenderer> ();
		renderer.enabled = false;

		WaveManager.Instance.RegisterSpawnPoint (this);
	}
	
	void Update () 
	{
		
	}


}
