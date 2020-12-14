using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject platformDestroyPoint;

    // Start is called before the first frame update
    void Start()
    {
        platformDestroyPoint = GameObject.Find("PlatformDestroyPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < platformDestroyPoint.transform.position.y)
        {
            //  Destroy(gameObject); 

            gameObject.SetActive(false);
        }
    }
}
