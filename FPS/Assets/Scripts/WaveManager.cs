using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

	public Text waveLabel;
	public float textInterval = 1f;

	void Start () 
	{
		
	}
	
	void Update () 
	{
//		if (Input.GetKeyDown (KeyCode.Q))
//		{
//			ChangeWave (i);
//			i += 1;
//		}
	}

	void HideWaveText()
	{
		waveLabel.text = "";
	}

	void ChangeWave(int wave)
	{
		if (wave == 1)
		{
			waveLabel.text = "WAVE ONE";
		}
		else if (wave == 2)
		{
			waveLabel.text = "WAVE TWO";
		}
		else if (wave == 3)
		{
			waveLabel.text = "WAVE THREE";
		}
		else if (wave == 4)
		{
			waveLabel.text = "WAVE FOUR";
		}
		else if (wave == 5)
		{
			waveLabel.text = "WAVE FIVE";
		}
		else if (wave == 6)
		{
			waveLabel.text = "WAVE SIX";
		}
		else if (wave == 7)
		{
			waveLabel.text = "WAVE SEVEN";
		}
		else if (wave == 8)
		{
			waveLabel.text = "WAVE EIGHT";
		}
		else if (wave == 9)
		{
			waveLabel.text = "WAVE NINE";
		}
		else if (wave == 10)
		{
			waveLabel.text = "WAVE TEN";
		}
		else if (wave == 11)
		{
			waveLabel.text = "WAVE ELEVEN";
		}
		else if (wave == 12)
		{
			waveLabel.text = "WAVE TWELVE";
		}

		Invoke ("HideWaveText", textInterval);
	}
}
