using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject thePlatform;
  //  public GameObject[] thePlatforms;
    public Transform generationPoint;
    public PlatformPooler[] objPlatformPooler;
   // public GameObject[] platforms;

    public float distanceBetween;
    private float platformWidth;
    public float distanceMin;
    public float distanceMax;
    private int platformSelector;
    private float[] platformWidths;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;


    private void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.y;

        //Get sizes of the prefabs in the list
        platformWidths = new float[objPlatformPooler.Length];

        for(int i = 0; i < objPlatformPooler.Length; i++)
        {
            platformWidths[1] = objPlatformPooler[i].platformPool.GetComponent<BoxCollider2D>().size.y;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
    }

    private void Update()
    {
        if(transform.position.y < generationPoint.position.y)
        {
            distanceBetween = Random.Range(distanceMin,distanceMax);
            platformSelector = Random.Range(0, objPlatformPooler.Length);
            heightChange = transform.position.x + Random.Range(maxHeightChange, -maxHeightChange);
            transform.position = new Vector3(heightChange, transform.position.y + (platformWidths[platformSelector]/2) + distanceBetween, transform.position.z);
            // Instantiate(thePlatform, transform.position, transform.rotation);

            //randomly select bettwen prefab list
            //Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);

            //Create new platform into list as active
            GameObject newPlatform = objPlatformPooler[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            transform.position = new Vector3(transform.position.x, transform.position.y + (platformWidths[platformSelector] / 2), transform.position.z);

        }
    }
}
