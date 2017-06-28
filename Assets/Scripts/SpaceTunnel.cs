using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTunnel : MonoBehaviour {

	public float speed = 0.25f;

	// Update is called once per frame
	void Update () {
		transform.position += (Vector3.forward * speed);
	}
}