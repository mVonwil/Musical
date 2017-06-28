using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampOnRoad : MonoBehaviour {

	public float speed = 0.25f;
	public Quaternion playerRot;

	void Start(){
		playerRot = transform.rotation;
	}

	void FixedUpdate(){
		transform.position += (Vector3.forward * speed);
	}
}