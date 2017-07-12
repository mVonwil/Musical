using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour {

	public Vector3 camTrans;
	public Transform playerTrans;
	public Vector3 camOffset = new Vector3 (0, 3f, -10f);

	// Use this for initialization
	void Start () {
		camTrans = transform.position;
		playerTrans = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		camTrans = playerTrans.position + camOffset;
		transform.position = camTrans;
	}
}
