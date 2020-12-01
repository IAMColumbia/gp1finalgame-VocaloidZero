using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepGenerator : MonoBehaviour
{
    public PlatformPooler pickupPool;

    public void SpawnSheep(Vector3 startPos)
    {
        //create pickup in the world
        GameObject sheep = pickupPool.GetPooledObject();
        sheep.transform.position = startPos;
        sheep.SetActive(true);
    }
}
