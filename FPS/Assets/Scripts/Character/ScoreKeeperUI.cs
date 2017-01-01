using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeperUI : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	void Update () 
	{
		scoreText.text = ScoreKeeper.Instance.score.ToString(); 
		highScoreText.text = ScoreKeeper.Instance.highScore.ToString ();
	}
}
