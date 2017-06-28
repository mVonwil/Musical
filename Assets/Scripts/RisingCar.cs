using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingCar : MonoBehaviour {

	public float speed = 0.25f;
	public float riseSpeed = 0.01f;

	// Update is called once per frame
	void FixedUpdate () {
		transform.position += (Vector3.forward * speed);
		transform.position += (Vector3.up * riseSpeed);
	}
}
