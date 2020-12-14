using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public UserController player;

    private Vector3 lastPos;
    private float distanceToMove;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<UserController>();
        lastPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        distanceToMove = player.transform.position.y - lastPos.y;
        this.transform.position = new Vector3(transform.position.x, transform.position.y + distanceToMove, transform.position.z);
        lastPos = player.transform.position;

    }
}
