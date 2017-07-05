using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour {

	public Vector3 camTrans;
	public Transform playerTrans;
	public Vector3 camOffset;

	// Use this for initialization
	void Start () {
		camTrans = transform.position;
		camOffset = new Vector3 (0, 1.5f, -5f);
		playerTrans = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		camTrans = playerTrans.position + camOffset;
		transform.position = camTrans;
	}
}
