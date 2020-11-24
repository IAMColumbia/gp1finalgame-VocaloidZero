using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRestricted : PlayerController
{
    private Player player;

    private bool hasJumped;
    public float jumpForce;
    public int extraJumpValue;
    public int extraJumps;

    void Start()
    {
        extraJumpValue = 2;
        player = GetComponent<Player>();
    }

    private void Update()
    {
        hasJumped = false;   
    }

    private void FixedUpdate()
    {
        UpdateMovement();
    }

    protected override void UpdateMovement()
    {
        base.UpdateMovement();

        if (player.onGround == true)
        {
            extraJumps = extraJumpValue;
        }
        if (Input.GetKey("up") && extraJumps > 0)
        {
            this.direction = direction * jumpForce;
            extraJumps--;
        }
        if (Input.GetKey("up") && extraJumps == 0 && player.onGround == true)
        {
           this.direction = direction * jumpForce;
        }
        if (Input.GetKey("up") && extraJumps == 0 && player.onGround == false)
        {
            this.direction.y = 0;
        }

    }
}
