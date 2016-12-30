using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfterTime : MonoBehaviour {

	public float lifeSpan;
	private float lifeStart;

	// Use this for initialization
	void Start () {
		lifeStart = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time > (lifeSpan + lifeStart))
		{
			Destroy (this.gameObject);
		}
	}
}
