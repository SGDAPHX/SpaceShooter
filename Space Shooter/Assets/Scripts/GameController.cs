using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazards;
	public GUIText gameOverText;
	public GUIText restartText;
	private bool bGameOver, bRestart;

	public Vector3 spawnValue;
	public int numHostiles = 10;
	public int hosIncreaseRate = 1;
	public float spawnWait   = 1.0f;
	public float spawnWaitMin   = 1.0f;
	public int spawnWaitRateDecrease   = 3;

	public float WaveWait    = 10f;

	void Start()
	{
		bGameOver = bRestart = false;
		restartText.text = gameOverText.text = "";
		StartCoroutine ("SpawnWaves");
	}
	void Update()
	{
		if (bRestart && Input.GetKeyDown(KeyCode.R)) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
	IEnumerator SpawnWaves()
	{
	

		for (int i = 0; i < numHostiles; ++i) {
			yield return new WaitForSeconds (spawnWait);
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValue.x, spawnValue.x), 0, spawnValue.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (hazards, spawnPosition, spawnRotation);
		}
		
		yield return new WaitForSeconds (WaveWait);
		// increase diificulty over time
		if (spawnWait > spawnWaitMin && numHostiles % spawnWaitRateDecrease == 0) 
		{
			//decrease time between spawns
			spawnWait -= 0.1f;
			if(spawnWait < spawnWaitMin){spawnWait = spawnWaitMin;}
		}
		//increase entities spawned per wave
		numHostiles += hosIncreaseRate;
		////////restart coRoutine

		StartCoroutine ("SpawnWaves");
	}

	public void GameOver()
	{
		gameOverText.text = "GameOver";
		bGameOver = true;
		restartText.text = "press r to restart";
		bRestart = true;
	}
}
