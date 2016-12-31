using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

	public int score;
	public int highScore;
	public static ScoreKeeper Instance;

	void Start () 
	{
		Instance = this;

		highScore = PlayerPrefs.GetInt ("highScore", 0);
		print ("Game started, we loaded a highscore of: " + highScore);
	}
	
	void Update () {
		
	}

	public void AddScore(int boost)
	{
		score += boost;
		print (score);

		if (score > highScore)
		{
			highScore = score;
			PlayerPrefs.SetInt ("highScore", highScore);
		}
	}

	void ResetScore()
	{
		score = 0;
		print (score);
	}
}
