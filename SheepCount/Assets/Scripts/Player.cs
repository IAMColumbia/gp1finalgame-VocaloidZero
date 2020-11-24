using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    //public float jumpForce;
    //public int extraJumpValue;
    ////private int extraJumps;
    private bool facingRight = false;
    

    //Check if on ground
    //public bool onGround;
    //public Transform groundCheck;
    //public float groundRadius;
    //public LayerMask whatIsGround;

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
    }
    private void FixedUpdate()
    {
        //Update Player position
        //UpdateInput();
        //rb2D.MovePosition(rb2D.position + direction * speed * Time.fixedDeltaTime);
        rb2D.velocity = new Vector2(playerController.moveInput * speed, rb2D.velocity.y);
        //direction.Normalize();

        ////ground check
        //onGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        //Flip player
        if (facingRight == false && playerController.moveInput > 0 || facingRight == true && playerController.moveInput < 0)
        {
            Flip();
        }

    }
    void Update()
    {

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

}
