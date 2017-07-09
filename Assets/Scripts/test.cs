using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public Renderer rend;

    Vector3 boundMin;
    Vector3 boundMax;

    Vector3 boundPoint1;
    Vector3 boundPoint4;



    Vector3 boundPoint5;
    Vector3 boundPoint6;
    Vector3 boundPoint7;
    Vector3 boundPoint8;


    void Start()
    {
        rend = GetComponent<Renderer>();
        boundMin = rend.bounds.min;
        boundMax = rend.bounds.max;

        boundPoint1 = new Vector3(boundMin.x, boundMin.y, boundMax.z);

        //Bottom 
        boundPoint4 = new Vector3(boundMin.x, boundMax.y, boundMin.z);


        boundPoint5 = new Vector3(boundMax.x, boundMin.y, boundMin.z);
        boundPoint6 = new Vector3(boundMin.x, boundMax.y, boundMax.z);
        boundPoint7 = new Vector3(boundMax.x, boundMin.y, boundMax.z);
        boundPoint8 = new Vector3(boundMax.x, boundMax.y, boundMin.z);
    }

    private void Update()
    {
        //if you want to visualize the box you can add to MrSkiz's code:
        Color lineColor = Color.red;

        //Diagonal
        Debug.DrawLine(boundMax, boundPoint4, lineColor);

        //TopLeft -> Bottom Left
        Debug.DrawLine(boundPoint6, boundMax, lineColor);

        //TopRight -> Bottom Right
        Debug.DrawLine(boundMax, boundPoint8, lineColor);




    }
}

