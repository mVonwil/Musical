using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingRoad : MonoBehaviour {

	public Rigidbody rb;

	// Update is called once per frame
	void FixedUpdate () {
		//transform.localPosition += (transform.forward / 2);
		//rb.AddForce (transform.forward * 50);
		rb.MovePosition(transform.position + (Vector3.forward + transform.forward).normalized / 3);
	}
}
