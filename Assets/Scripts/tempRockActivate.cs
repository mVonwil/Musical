using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempRockActivate : MonoBehaviour {

	public GameObject rock1;
	public GameObject rock2;
	public GameObject rock3;
	public GameObject rock4;
	
	// Update is called once per frame
	void Update () {
		RockActive ();
	}

	void RockActive(){
		if (Input.GetKeyDown(KeyCode.Alpha0)){
			rock1.SetActive(false);
			rock2.SetActive(false);
			rock3.SetActive(false);
			rock4.SetActive(false);
		}
		if (Input.GetKeyDown(KeyCode.Alpha1)){
			rock1.SetActive(true);
			rock2.SetActive(false);
			rock3.SetActive(false);
			rock4.SetActive(false);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)){
			rock1.SetActive(true);
			rock2.SetActive(true);
			rock3.SetActive(false);
			rock4.SetActive(false);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)){
			rock1.SetActive(true);
			rock2.SetActive(true);
			rock3.SetActive(true);
			rock4.SetActive(false);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4)){
			rock1.SetActive(true);
			rock2.SetActive(true);
			rock3.SetActive(true);
			rock4.SetActive(true);
		}
	}
}
