using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aRoad : MonoBehaviour {

    public Vector3 pos;
    public Quaternion rot;
    public string roadName;
    public string blockName;
    public bool corner = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pos = this.gameObject.transform.position;
        rot = this.gameObject.transform.rotation;

    }
}
