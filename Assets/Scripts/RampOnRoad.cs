using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampOnRoad : MonoBehaviour {

	public float speed = 0.25f;

	void FixedUpdate(){
		transform.position += (Vector3.forward * speed);
	}
}