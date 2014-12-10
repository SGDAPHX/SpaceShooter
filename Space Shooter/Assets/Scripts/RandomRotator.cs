using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	public float tumble = 0;

	void Start()
	{
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
