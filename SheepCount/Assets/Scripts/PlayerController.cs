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

    public PlayerController()
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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        UpdateKeyboardInput();

    }

    protected virtual void UpdateKeyboardInput()
    {
        //direction.x = direction.y = 0;
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

        if (Input.GetKeyDown("up"))
        {
            keyDirection.y += 1;

        }




        direction += keyDirection;
        direction.Normalize();
    }

}
