using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	private GameController GC;
	public int scoreValue = 10;

	void Start()
	{
		GC = GameObject.Find ("GameController").GetComponent<GameController>();
	}
	void OnTriggerEnter(Collider other)
	{
		//Debug.Log (other.name);
		if (other.tag != "Boundary") 
		{
			Instantiate(explosion,transform.position,transform.rotation);
			if(other.tag == "Player")
			{
			Instantiate(playerExplosion,other.transform.position,other.transform.rotation);
				GC.GetComponent<GameController>().GameOver();
			}else
			{
					GC.addScore(scoreValue);
			}
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
