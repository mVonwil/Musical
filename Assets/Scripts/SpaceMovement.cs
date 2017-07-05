using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMovement : MonoBehaviour {

	public Quaternion playerRot;
	public GameObject parentObj;
	public Vector3 parentPos;
	public float RotSpeed;
	public float slideSpeed;
	public int slideLimit;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		playerRot = transform.rotation;
		parentObj = GameObject.FindGameObjectWithTag ("PlayerMover");
		parentPos = parentObj.transform.localPosition;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		PlayerRotate ();
		PlayerSlide ();
	}

	void PlayerRotate(){
		if (Input.GetKey (KeyCode.A)) {
			playerRot.z += RotSpeed * Time.deltaTime;
			transform.Rotate (new Vector3 (0, 0, RotSpeed * Time.deltaTime));
		} else if (Input.GetKey (KeyCode.D)) {
			playerRot.z -= RotSpeed * Time.deltaTime;
			transform.Rotate (new Vector3 (0, 0, -RotSpeed * Time.deltaTime));
		}
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
