using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour {

	public GameObject parentObj;
	public Vector3 parentPos;
	public float slideSpeed;
	public int slideLimit;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		parentObj = GameObject.FindGameObjectWithTag ("PlayerMover");
		parentPos = parentObj.transform.localPosition;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		PlayerSlide ();
	}

	void PlayerSlide(){
		if (Input.GetKey (KeyCode.D)) {
			parentPos.x += slideSpeed * Time.deltaTime;
			parentObj.transform.localPosition = parentPos;
			if (parentPos.x >= slideLimit)
				parentPos.x = slideLimit;
		} else if (Input.GetKey (KeyCode.A)) {
			parentPos.x -= slideSpeed * Time.deltaTime;
			parentObj.transform.localPosition = parentPos;
			if (parentPos.x <= -slideLimit)
				parentPos.x = -slideLimit;
		}
	}
}
