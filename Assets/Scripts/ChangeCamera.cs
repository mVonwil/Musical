using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {

	public Camera cam1;
	public Camera cam2;
	public Camera cam3;
	public Camera cam4;
	public Camera cam5;
	public Camera cam6;
	public Camera cam7;
	public Camera cam8;
	public Camera cam9;
	public Camera cam0;

	void Start(){
		cam1.enabled = true;
		cam2.enabled = false;
		cam3.enabled = false;
		cam4.enabled = false;
		cam5.enabled = false;
		cam6.enabled = false;
		cam7.enabled = false;
		cam8.enabled = false;
		cam9.enabled = false;
		cam0.enabled = false;
	}

	void Update(){
		CameraChange ();
	}

	void CameraChange(){
		if (Input.GetKeyDown(KeyCode.Alpha1)){
			cam1.enabled = true;
			cam2.enabled = false;
			cam3.enabled = false;
			cam4.enabled = false;
			cam5.enabled = false;
			cam6.enabled = false;
			cam7.enabled = false;
			cam8.enabled = false;
			cam9.enabled = false;
			cam0.enabled = false;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)){
			cam1.enabled = false;
			cam2.enabled = true;
			cam3.enabled = false;
			cam4.enabled = false;
			cam5.enabled = false;
			cam6.enabled = false;
			cam7.enabled = false;
			cam8.enabled = false;
			cam9.enabled = false;
			cam0.enabled = false;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)){
			cam1.enabled = false;
			cam2.enabled = false;
			cam3.enabled = true;
			cam4.enabled = false;
			cam5.enabled = false;
			cam6.enabled = false;
			cam7.enabled = false;
			cam8.enabled = false;
			cam9.enabled = false;
			cam0.enabled = false;
		}
		if (Input.GetKeyDown(KeyCode.Alpha4)){
			cam1.enabled = false;
			cam2.enabled = false;
			cam3.enabled = false;
			cam4.enabled = true;
			cam5.enabled = false;
			cam6.enabled = false;
			cam7.enabled = false;
			cam8.enabled = false;
			cam9.enabled = false;
			cam0.enabled = false;
		}
		if (Input.GetKeyDown(KeyCode.Alpha5)){
			cam1.enabled = false;
			cam2.enabled = false;
			cam3.enabled = false;
			cam4.enabled = false;
			cam5.enabled = true;
			cam6.enabled = false;
			cam7.enabled = false;
			cam8.enabled = false;
			cam9.enabled = false;
			cam0.enabled = false;
		}
		if (Input.GetKeyDown(KeyCode.Alpha6)){
			cam1.enabled = false;
			cam2.enabled = false;
			cam3.enabled = false;
			cam4.enabled = false;
			cam5.enabled = false;
			cam6.enabled = true;
			cam7.enabled = false;
			cam8.enabled = false;
			cam9.enabled = false;
			cam0.enabled = false;
		}
		if (Input.GetKeyDown(KeyCode.Alpha7)){
			cam1.enabled = false;
			cam2.enabled = false;
			cam3.enabled = false;
			cam4.enabled = false;
			cam5.enabled = false;
			cam6.enabled = false;
			cam7.enabled = true;
			cam8.enabled = false;
			cam9.enabled = false;
			cam0.enabled = false;
		}
		if (Input.GetKeyDown(KeyCode.Alpha8)){
			cam1.enabled = false;
			cam2.enabled = false;
			cam3.enabled = false;
			cam4.enabled = false;
			cam5.enabled = false;
			cam6.enabled = false;
			cam7.enabled = false;
			cam8.enabled = true;
			cam9.enabled = false;
			cam0.enabled = false;
		}
		if (Input.GetKeyDown(KeyCode.Alpha9)){
			cam1.enabled = false;
			cam2.enabled = false;
			cam3.enabled = false;
			cam4.enabled = false;
			cam5.enabled = false;
			cam6.enabled = false;
			cam7.enabled = false;
			cam8.enabled = false;
			cam9.enabled = true;
			cam0.enabled = false;
		}
		if (Input.GetKeyDown(KeyCode.Alpha0)){
			cam1.enabled = false;
			cam2.enabled = false;
			cam3.enabled = false;
			cam4.enabled = false;
			cam5.enabled = false;
			cam6.enabled = false;
			cam7.enabled = false;
			cam8.enabled = false;
			cam9.enabled = false;
			cam0.enabled = true;
		}
	}
}