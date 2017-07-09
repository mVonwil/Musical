using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aRoad : MonoBehaviour {

    public Vector3 pos;
    public Quaternion rot;
    public string roadName;
    public string blockName;
    public bool corner = false;
    Renderer rend;
    public Vector3 center;
    public Vector3 max;
    public Vector3 min;
    public Vector3 test;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        center = rend.bounds.center;
        max = rend.bounds.max;
        min = rend.bounds.min;
        test = rend.bounds.extents;

        //Left Side
        //(center.x - v3ext.x, v3Center.y + v3ext.y, v3Center.z - v3ext.z)

        //Right Side

    }
	
	// Update is called once per frame
	void Update () {
        pos = this.gameObject.transform.position;
        rot = this.gameObject.transform.rotation;

    }
}
