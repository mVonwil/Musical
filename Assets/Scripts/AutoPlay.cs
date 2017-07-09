using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AutoPlay : MonoBehaviour {

    //The first method is that the player will move along the road only. 
    //The second method is the road will move and the player will stay still. (Currently Not Working)
    // BOTH can have certain flags that change this later on if needed.
    [SerializeField]
    bool usingFirstMethod = false;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float slerpSpeed, lerpSpeed;
    [SerializeField]
    GameObject playerPosition;
    [SerializeField]
    List<GameObject> roads;
    [SerializeField]
    List<GameObject> blocks = null;
    [SerializeField]
    float waitSeconds;

    float dist;
    int currentRoadBlock, currentBlock;
    GameObject par = null;
    bool isCorner = false;
    Vector3 destPos = new Vector3(-11, 0, 6.8f);
    bool playerControlling = false;
    bool startTimer = false;
    float playerTimer = 0;


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
    void Update() {

        //Method involves making the road in any way then making the player move along it.
        if (!usingFirstMethod)
        {

            if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D)))
                playerControlling = true;


            if (playerControlling)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    playerControlling = true;
                    transform.Translate(-Vector3.right * moveSpeed);
                    //frontCar.transform.position = Vector3.Lerp(frontCar.transform.position, new Vector3(frontCar.transform.position.x - 4f, frontCar.transform.position.y, frontCar.transform.position.z), slerpSpeed);
                    startTimer = true;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    playerControlling = true;
                    transform.Translate(Vector3.right * moveSpeed);
                    //frontCar.transform.position = Vector3.Lerp(frontCar.transform.position, new Vector3(frontCar.transform.position.x + 4f, frontCar.transform.position.y, frontCar.transform.position.z), slerpSpeed);
                    startTimer = true;
                }
            }
            else
            {
                //Slerp to the right rotation
                transform.rotation = Quaternion.Slerp(playerPosition.transform.rotation, roads[currentRoadBlock].GetComponent<aRoad>().rot, slerpSpeed);
                //transform.rotation = Quaternion.Slerp(frontCar.transform.rotation, roads[currentRoadBlock].GetComponent<aRoad>().rot, slerpSpeed);
            }

            if (startTimer)
                playerTimer += Time.deltaTime;

            if (playerTimer < waitSeconds)
            {
                startTimer = false;
                playerControlling = false;
                playerTimer = 0;
            }

           //frontCar.transform.position = Vector3.Lerp(frontCar.transform.position, new Vector3(playerPosition.transform.position.x,playerPosition.transform.position.y, frontCar.transform.position.z), slerpSpeed);
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

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Road")
        {
            //Debug.Log("PLayer has left");
            //Check if player bounds intercepts the roads bounds 
            //If it returns true clamp the player inside those bounds


        }
    }
}
