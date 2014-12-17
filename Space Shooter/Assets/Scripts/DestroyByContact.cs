using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	private GameController gameController;
	public int scoreValue = 0;
	void Start()
	{
		GameObject GC = GameObject.FindWithTag ("GameController");
		if (GC != null)
		{
			gameController = GC.GetComponent<GameController>();
		}
		if (gameController == null) 
		{

			Debug.Log("Can not Fing game Controller instance");
		}
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
			}
			else
			{
				gameController.addScore(scoreValue);
			}
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
