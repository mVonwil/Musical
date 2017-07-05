using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

	void OnTriggerEnter(Collider player){
		if (player.gameObject.tag == "Player") {
			Debug.Log("load space");
			SceneManager.LoadScene("Space");
		}
	}
}