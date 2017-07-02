using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findCenter : MonoBehaviour {

    GameObject player;
    public Vector3 roadCenterPos;
    Renderer rend;
    Transform parent;
    float distance = 15;

    private void Start()
    {
        parent = this.gameObject.transform.parent;
        player = GameObject.FindGameObjectWithTag("Player");
        rend = parent.GetComponent<Renderer>();
    }
    // Update is called once per frame
    void Update () {


        roadCenterPos = rend.bounds.center;
        transform.position = roadCenterPos;

    }

    //WHEN THE PLAYER HITS THE COLLIDER
    //MAKE SURE THE PLAYER IS ALWAYS INLINE WITH THE CENTER OBJECT!!!
    //DO THIS BY MOVING THE PARENT OBJECT LEFT OR RIGHT.
}
