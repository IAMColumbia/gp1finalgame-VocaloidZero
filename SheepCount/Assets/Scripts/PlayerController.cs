using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Vector2 direction = new Vector2();
    public Vector2 keyDirection;
    public bool IsKeyDown
    {
        get
        {
            if (keyDirection.sqrMagnitude == 0) return false;
            return true;
        }
    }

    void Start()
    {

    }
    void Awake()
    {
        AwakeKeyDirection();
    }

    private void AwakeKeyDirection()
    {
        keyDirection = new Vector2();
    }
    void FixedUpdate()
    {
       // UpdateMovement();

    }

    private void Update()
    {
    }

    protected virtual void UpdateMovement()
    {

        //Movement
        //moveInput = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        keyDirection.x = keyDirection.y = 0;

        //Keyboard
        if (Input.GetKey("right"))
        {
            keyDirection.x += 1;
        }
        if (Input.GetKey("left"))
        {
            keyDirection.x += -1;
        }
        if (Input.GetKey("up"))
        {
            keyDirection.y += 1;
        }


        direction += keyDirection;
        direction.Normalize();
    }

}
