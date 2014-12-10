using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{

	public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour {

	public Vector2 speed = new Vector2 (1, 1);
	public float tilt;
	public Boundary bound;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 0.5f;
	private float nextFire = 0;
	void FixedUpdate()
	{
		float moveH = speed.x * Input.GetAxis ("Horizontal");
		float moveV = speed.y * Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveH, 0, moveV);
		rigidbody.velocity = movement;

		rigidbody.position = new Vector3 
			(
				Mathf.Clamp(rigidbody.position.x,bound.xMin,bound.xMax),
				0,
				Mathf.Clamp(rigidbody.position.z,bound.zMin, bound.zMax));
		rigidbody.rotation = Quaternion.Euler (0, 0, rigidbody.velocity.x * -tilt);
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
