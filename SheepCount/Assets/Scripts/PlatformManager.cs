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

    //public Transform maxHeightPoint; //y axis limit
    public Transform maxXPoint;
    public Transform minXPoint;
    private float minX;
    private float maxX;
    public float maxXChange;
    private float xDistanceChange;

    //referance to pickups
    private SheepGenerator sheepGenerator;
    public float randomSheepRange;




    private void Start()
    {
        //Get sizes of the prefabs in the list
        PlatformSetup();
    }

    private void PlatformSetup()
    {
        platformWidths = new float[objPlatformPooler.Length];

        //Get platform prefab widths
        for (int i = 0; i < objPlatformPooler.Length; i++)
        {
            platformWidths[i] = objPlatformPooler[i].platformPool.GetComponent<BoxCollider2D>().size.y;
        }

        //restrict how far the platform can instantiate at
        minX = minXPoint.position.x;
        maxX = maxXPoint.position.x;

        sheepGenerator = FindObjectOfType<SheepGenerator>();
    }

    private void Update()
    {

        if (transform.position.y < generationPoint.position.y)
        {

            distanceBetweenY = Random.Range(distanceMin, distanceMax); //distance between platforms on the y axis
            platformSelector = Random.Range(0, objPlatformPooler.Length); //selecting between platform prefabs
            //heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange); //x axis range
            xDistanceChange = transform.position.x + Random.Range(-maxXChange, maxXChange); //x axis range

            //x axis distance randomness but never beyond the max points
            if (xDistanceChange > maxX)
            {
                xDistanceChange = maxX;
            }
            else if (xDistanceChange < minX)
            {
                xDistanceChange = minX; 
            }

            //set platform position with distance
            transform.position = new Vector3(xDistanceChange, transform.position.y + (platformWidths[platformSelector] / 2) + distanceBetweenY, transform.position.z);

            //Create new platform into list as active
            GameObject newPlatform = objPlatformPooler[platformSelector].GetPooledObject();

            //Retain prefav position and rotation and set to ACTIVE
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            //Randomly spawn coins depending on range
            if(Random.Range(0f,100f) < randomSheepRange)
            {
                //create pickups on platform
                sheepGenerator.SpawnSheep(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }

            transform.position = new Vector3(transform.position.x, transform.position.y + (platformWidths[platformSelector] / 2), transform.position.z);

        }
    }
}
