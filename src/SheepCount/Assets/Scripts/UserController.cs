using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour
{
    //references
    public Player player;


    public float moveInput;


    private void Start()
    {
        //jumpNoise = GetComponent<AudioSource>();
        player = GetComponent<Player>();
    }

    private void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown("up"))
        {
            player.Jump();
        }
        player.CheckifOnGround();

    }

  
}
