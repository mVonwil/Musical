using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampOnRoad : MonoBehaviour {

	public Quaternion playerRot;

	void Start(){
		playerRot = transform.rotation;
	}

	void FixedUpdate(){
		transform.position += (Vector3.forward / 5);
	}
}