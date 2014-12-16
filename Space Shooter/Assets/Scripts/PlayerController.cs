using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{

	public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {

	public float maxEnergy = 10;
	public float currEnergy;

	private float boostCost = 5;

	public Vector2 speed = new Vector2 (1, 1);
	public float tilt;
	public Boundary bound;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 0.5f;
	private float nextFire = 0;

	void Start()
	{
		currEnergy = maxEnergy;
	}

	void FixedUpdate()
	{

		//regen energy
		if (currEnergy < maxEnergy) 
		{
			currEnergy += Time.deltaTime;
			if(currEnergy > maxEnergy)
			{
				currEnergy = maxEnergy;
			}
		}

		float moveH = speed.x * Input.GetAxis ("Horizontal");
		float moveV = speed.y * Input.GetAxis ("Vertical");
		if (Input.GetKey (KeyCode.LeftShift) && currEnergy > boostCost) 
		{
			moveH 		*= 2;
			currEnergy 	-= boostCost * Time.deltaTime;
		}

		Vector3 movement = new Vector3 (moveH, 0, moveV);
		rigidbody.velocity = movement;

		rigidbody.position = new Vector3 
			(
				Mathf.Clamp(rigidbody.position.x,bound.xMin,bound.xMax),
				0,
				Mathf.Clamp(rigidbody.position.z,bound.zMin, bound.zMax));
				rigidbody.rotation = Quaternion.Euler (0, 0, rigidbody.velocity.x * -tilt
		    );

	}

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			GameObject clone = Instantiate (shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
		}
	}
}
