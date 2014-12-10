using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazards;
	public Vector3 spawnValue;

	void Start()
	{
		SpawnWaves ();
	}
	void SpawnWaves()
	{
		Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x,spawnValue.x),0,spawnValue.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazards, spawnPosition, spawnRotation);
	}
}
