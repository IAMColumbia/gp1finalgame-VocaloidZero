using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public Transform generationPoint;
    public PlatformPooler[] objPlatformPooler;

    public float distanceBetweenY; //distance between platforms on the y-axis
    public float distanceMin; //minimum range on y-axis
    public float distanceMax; //max range on y-axis

    //list of platforms to chose from if more than 1 type
    private int platformSelector;
    private float[] platformWidths;

    //Restricting platforms so that they are not out of reach for the player
    //public Transform maxHeightPoint; //y axis limit
    ////public Transform maxXPoint;
    //private float minHeight; 
    //private float maxHeight;
    //public float maxHeightChange;
    //private float heightChange;

    //public Transform maxHeightPoint; //y axis limit
    public Transform maxXPoint;
    private float minX;
    private float maxX;
    public float maxXChange;
    private float xDistanceChange;



    private void Start()
    {
        //Get sizes of the prefabs in the list
        PlatformSetup();
    }

    private void PlatformSetup()
    {
        platformWidths = new float[objPlatformPooler.Length];

        for (int i = 0; i < objPlatformPooler.Length; i++)
        {
            platformWidths[i] = objPlatformPooler[i].platformPool.GetComponent<BoxCollider2D>().size.y;
        }

        //restrict how high the platform can instantiate at
        minX = transform.position.x;
        maxX = maxXPoint.position.x;
    }

    private void Update()
    {

        //if(transform.position.y < generationPoint.position.y)
        //{
        //    transform.position = new Vector3(transform.position.x,transform.position.y + platformWidth + distanceBetween, transform.position.z);

        //    Instantiate(thePlatform,transform.position, transform.rotation);
        //}


        if (transform.position.y < generationPoint.position.y)
        {

            distanceBetweenY = Random.Range(distanceMin, distanceMax); //distance between platforms on the y axis
            platformSelector = Random.Range(0, objPlatformPooler.Length); //selecting between platform prefabs
            //heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange); //x axis range
            xDistanceChange = transform.position.x + Random.Range(-maxXChange, maxXChange); //x axis range

            //x axis distance randomness
            if (xDistanceChange > maxX)
            {
                xDistanceChange = maxX; //+ Random.Range(-2, 10);
            }
            else if (xDistanceChange < minX)
            {
                xDistanceChange = minX + Random.Range(-2, 5);
            }

            //set platform position with distance
            transform.position = new Vector3(xDistanceChange, transform.position.y + (platformWidths[platformSelector] / 2) + distanceBetweenY, transform.position.z);

            //Create new platform into list as active
            GameObject newPlatform = objPlatformPooler[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            //
            transform.position = new Vector3(transform.position.x, transform.position.y + (platformWidths[platformSelector] / 2), transform.position.z);

        }
    }
}
