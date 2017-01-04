using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour {

	public Text waveLabel;
	public float textInterval = 3f;

	public ArrayList enemyList;
	public ArrayList spawnPoints;

	public static WaveManager Instance;
	public GameObject enemyPrefab;

	private int wave;

	private bool hasStarted = false;

	void Awake()
	{
		Invoke ("StartGame", 3f);

		Instance = this;

		spawnPoints = new ArrayList ();
		enemyList = new ArrayList ();

	}

	void Update()
	{
		if (enemyList.Count == 0 && hasStarted)
		{
			ChangeWave (wave + 1);
		}
	}

	public void SignalDeath(GameObject deadEnemy)
	{
		enemyList.Remove (deadEnemy);
		print (enemyList.Count);
	}

	public void RegisterSpawnPoint(SpawnPoint spawnPoint)
	{
		spawnPoints.Add (spawnPoint);
	}

	void StartGame()
	{
		ChangeWave (1);
		hasStarted = true;
	}

	void HideWaveText()
	{
		waveLabel.text = "";
	}

	void SpawnEnemy()
	{
		if (spawnPoints.Count > 0)
		{
			int r = Random.Range (0, spawnPoints.Count - 1);
			SpawnPoint sp = spawnPoints [r] as SpawnPoint;
			if (sp.CheckClear ())
			{
				GameObject enemy = GameObject.Instantiate (enemyPrefab, sp.transform.position, sp.transform.rotation) as GameObject;
				enemyList.Add (enemy);
			} else
			{
				Invoke ("SpawnEnemy", .2f);
			}
		}
	}

	void ChangeWave(int wave)
	{
		this.wave = wave;
		if (wave == 1)
		{
			waveLabel.text = "WAVE ONE";

			SpawnEnemy ();
			SpawnEnemy ();
		}
		else if (wave == 2)
		{
			waveLabel.text = "WAVE TWO";

			SpawnEnemy ();
			SpawnEnemy ();

			SpawnEnemy ();
			SpawnEnemy ();
		}
		else if (wave == 3)
		{
			waveLabel.text = "WAVE THREE";

			for (int i = 0; i < 6; i++)
			{
				SpawnEnemy ();
			}
		}
		else if (wave == 4)
		{
			waveLabel.text = "WAVE FOUR";

			for (int i = 0; i < 7; i++)
			{
				SpawnEnemy ();
			}
		}
		else if (wave == 5)
		{
			waveLabel.text = "WAVE FIVE";

			for (int i = 0; i < 8; i++)
			{
				SpawnEnemy ();
			}
		}
		else if (wave == 6)
		{
			waveLabel.text = "WAVE SIX";

			for (int i = 0; i < 9; i++)
			{
				SpawnEnemy ();
			}
		}
		else if (wave == 7)
		{
			waveLabel.text = "WAVE SEVEN";

			for (int i = 0; i < 10; i++)
			{
				SpawnEnemy ();
			}
		}
		else if (wave == 8)
		{
			waveLabel.text = "WAVE EIGHT";

			for (int i = 0; i < 11; i++)
			{
				SpawnEnemy ();
			}
		}
		else if (wave == 9)
		{
			waveLabel.text = "WAVE NINE";

			for (int i = 0; i < 12; i++)
			{
				SpawnEnemy ();
			}
		}
		else if (wave == 10)
		{
			waveLabel.text = "WAVE TEN";

			for (int i = 0; i < 15; i++)
			{
				SpawnEnemy ();
			}
		}
		else if (wave == 11)
		{
			waveLabel.text = "WAVE ELEVEN";

			for (int i = 0; i < 20; i++)
			{
				SpawnEnemy ();
			}
		}
		else if (wave == 12)
		{
			waveLabel.text = "WAVE TWELVE";

			for (int i = 0; i < 30; i++)
			{
				SpawnEnemy ();
			}
		}

		Invoke ("HideWaveText", textInterval);
	}
}
