using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float choke; //making sure objects are stacking flush on each other
    public float scrollSpeed;

    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        //load in BG and all its children
        foreach (GameObject obj in levels)
        {
            loadChildObjects(obj);
        }
    }
    void loadChildObjects(GameObject obj)
    {
        //vertical value of object
        float objectHeight = obj.GetComponent<SpriteRenderer>().bounds.size.y - choke;
        //have enough clones to fill screen
        int childsNeeded = (int)Mathf.Ceil(screenBounds.y * 2 / objectHeight);
        GameObject clone = Instantiate(obj) as GameObject;

        //creating child objects
        for (int i = 0; i <= childsNeeded; i++)
        {
            //cloning
            GameObject c = Instantiate(clone) as GameObject;
            //set new clone to be child
            c.transform.SetParent(obj.transform);
            //spacing out
            c.transform.position = new Vector3(obj.transform.position.x, objectHeight * i, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }
    void repositionChildObjects(GameObject obj)
    {
        //create list of child objects in obj
        Transform[] children = obj.GetComponentsInChildren<Transform>();

        if (children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfHeight = lastChild.GetComponent<SpriteRenderer>().bounds.extents.y - choke;
            if (transform.position.y + screenBounds.y > lastChild.transform.position.y + halfHeight)
            {
                //move first child to last and reposition up
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x, lastChild.transform.position.y + halfHeight * 2, lastChild.transform.position.z);
            }
            else if (transform.position.y - screenBounds.y < firstChild.transform.position.y - halfHeight)
            {
                //move last child to first
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x, firstChild.transform.position.y - halfHeight * 2, firstChild.transform.position.z);
            }
        }
    }
    void Update()
    {
        //Scroll screen
        Vector3 velocity = Vector3.zero;
        Vector3 desiredPosition = transform.position + new Vector3(0, scrollSpeed, 0);
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.3f);
        transform.position = smoothPosition;

    }
    void LateUpdate()
    {
        foreach (GameObject obj in levels)
        {
            repositionChildObjects(obj);
        }
    }

}
