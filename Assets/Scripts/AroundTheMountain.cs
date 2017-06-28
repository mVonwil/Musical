using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundTheMountain : MonoBehaviour {

	public Quaternion groundRot;
	public Rigidbody rb;
	public float speed = 0.25f;

	void FixedUpdate(){
		rb.MovePosition(transform.position + (Vector3.left + transform.forward).normalized * speed);
	}

	void OnTriggerEnter(Collider plane){
		if (plane.gameObject.tag == "Plane") {
			groundRot = transform.rotation;
			groundRot.y += (plane.gameObject.transform.rotation.y);
			transform.rotation = groundRot;
		}
	}
}
