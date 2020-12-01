using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRestricted : PlayerController
{

    //Jump factors
    private bool hasJumped;
    public float jumpForce;
    public int extraJumpValue;
    public int extraJumps;

    //Check if on ground for jumping
    public bool onGround;
    public Transform groundCheck;
    public float groundRadius;
    public LayerMask whatIsGround;

    void Start()
    {
        extraJumpValue = 2;

    }

    private void Update()
    {
        hasJumped = false;   
    }

    private void FixedUpdate()
    {
        UpdateKeyboardInput();

        //ground check
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    protected override void UpdateKeyboardInput()
    {
        base.UpdateKeyboardInput();


        if (onGround == true)
        {
            extraJumps = extraJumpValue;
        }
        if (Input.GetKeyDown("up") && extraJumps > 0)
        {
            this.direction = direction * jumpForce;
            extraJumps--;
        }
        if (Input.GetKeyDown("up") && extraJumps == 0 && onGround == true)
        {
            this.direction = direction * jumpForce;
        }
        if (Input.GetKeyDown("up") && extraJumps == 0 && onGround == false)
        {
            this.direction.y = 0;
        }

    }
}
