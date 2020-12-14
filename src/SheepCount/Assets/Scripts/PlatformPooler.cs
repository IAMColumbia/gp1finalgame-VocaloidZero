using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPooler : MonoBehaviour
{
    public GameObject platformPool;
    public int poolAmount;
    List<GameObject> pooledObjects;

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();

        for(int i = 0; i < poolAmount; i++)
        {
            //fill list with platforms
            CreateObject();
        }
    }

    private void CreateObject()
    { 
        //Deactivted platform
        GameObject plate = (GameObject)Instantiate(platformPool);
        plate.SetActive(false);
        pooledObjects.Add(plate);
    }

    public GameObject GetPooledObject()
    {
        //pulling inactive plateform
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        GameObject plate = (GameObject)Instantiate(platformPool);
        plate.SetActive(false);
        pooledObjects.Add(plate);
        return plate;
    }
}
