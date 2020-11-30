using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    private bool facingRight = false;

    public Camera MainCamera; //TODO: Change how the camera follows 
    private Vector2 screenBounds;
    private float objectWidth;

    TestController playerController;
    public Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        playerController = GetComponent<TestController>();
        if (playerController == null)
        {
            playerController = this.gameObject.AddComponent<TestController>();
        }

        GetCameraXBoundries();
    }

    private void FixedUpdate()
    {
        //Update Player position

        rb2D.velocity = new Vector2(playerController.moveInput * speed, rb2D.velocity.y);
        //direction.Normalize();

        ////ground check
        //onGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        //Flip player
        if (facingRight == false && playerController.moveInput > 0 || facingRight == true && playerController.moveInput < 0)
        {
            Flip();
        }
        //if (facingRight == false && playerController.keyDirection.x > 0 || facingRight == true && playerController.keyDirection.x < 0)
        //{
        //    Flip();
        //}
    }

    void LateUpdate()
    {
        SetCameraXRestrictions();
    }


    void Update()
    {
        //UpdateInput();
       // rb2D.MovePosition(rb2D.position + direction * speed * Time.fixedDeltaTime);
    }
    //protected virtual void UpdateInput()
    //{
    //    if (playerController.IsKeyDown)
    //    {
    //        this.direction = playerController.direction;
    //    }
    //    else
    //    {
    //        this.direction = Vector3.zero;
    //    }
    //}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void GetCameraXBoundries()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
    }
    private void SetCameraXRestrictions()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        transform.position = viewPos;
    }

}
