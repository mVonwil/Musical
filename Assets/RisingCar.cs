using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingCar : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += (Vector3.forward / 5);
		transform.position += (Vector3.up / 50);
	}
}
