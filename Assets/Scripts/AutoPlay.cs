using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AutoPlay : MonoBehaviour {

    //The first method is that the player will move along the road only. 
    //The second method is the road will move and the player will stay still.
    // BOTH can have certain flags that change this later on if needed.
    [SerializeField]
    bool usingFirstMethod = false;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float dist;

    [SerializeField]
    float slerpSpeed, lerpSpeed;

    [SerializeField]
    GameObject playerPosition;

    [SerializeField]
    List<GameObject> roads;

    [SerializeField]
    List<GameObject> blocks = null;

    [SerializeField]
    int currentRoadBlock, currentBlock;

    [SerializeField]
    GameObject par = null;

    [SerializeField]
    bool isCorner = false;

    [SerializeField]
    Vector3 destPos = new Vector3(-11, 0, 6.8f);

    // Use this for initialization
    void Start () {
        playerPosition = this.gameObject;

        foreach (GameObject a in GameObject.FindGameObjectsWithTag("Road"))
        {
            roads.Add(a);
        }

        for (int i = 0; i < roads.Count; i++)
        {
            roads[i].GetComponent<aRoad>().roadName = i.ToString();
        }


        if (usingFirstMethod)
        {
            foreach (GameObject a in GameObject.FindGameObjectsWithTag("Road"))
            {
                blocks.Add(a.transform.parent.gameObject);
            }

            for (int i = 0; i < roads.Count; i++)
            {
                roads[i].GetComponent<aRoad>().blockName = i.ToString();
            }
        }

    }
	
	// Update is called once per frame
	void Update () {

        //Method involves making the road in any way then making the player move along it.
        if(!usingFirstMethod)
        {
            //Slerp to the right rotation
            transform.rotation = Quaternion.Slerp(playerPosition.transform.rotation, roads[currentRoadBlock].GetComponent<aRoad>().rot, slerpSpeed);

            transform.Translate(Vector3.forward * moveSpeed);
        }
        else if(usingFirstMethod)
        {
            foreach(GameObject a in blocks)
            {
                    a.transform.Translate(-Vector3.forward * moveSpeed);

            }
            //Check if the block is a corner
            if (isCorner)
            {
                blocks[3].gameObject.transform.position = Vector3.Slerp(blocks[3].gameObject.transform.position, destPos, lerpSpeed);
            }

        }
	}

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        if(other.gameObject.tag == "Road")
        {
            currentRoadBlock = Int32.Parse(other.GetComponent<aRoad>().roadName);

            if (usingFirstMethod)
            {
                currentBlock = Int32.Parse(other.GetComponent<aRoad>().blockName);
                GameObject child = other.gameObject;
                par = child.transform.parent.gameObject;

                if (other.gameObject.transform.Find("Center"))
                {
                    isCorner = true;
                }
                else
                    isCorner = false;

            }
        }
    }
}
