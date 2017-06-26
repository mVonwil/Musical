using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCollider : MonoBehaviour {

	public GameObject sampleRoad;

	void OnTriggerEnter(Collider car){
		if (car.gameObject.tag == "Player")
			Instantiate(sampleRoad, new Vector3(0, 0, 46), Quaternion.identity);
	}
}
