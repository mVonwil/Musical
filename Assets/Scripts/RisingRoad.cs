using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingRoad : MonoBehaviour {

	public Rigidbody rb;
	public float speed = 0.3f;

	// Update is called once per frame
	void FixedUpdate () {
		rb.MovePosition(transform.position + (Vector3.forward + transform.forward).normalized * speed);
	}
}
