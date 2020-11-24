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
    public bool onGround;
    public Transform groundCheck;
    public float groundRadius;
    public LayerMask whatIsGround;

    ControllerRestricted playerController;
    public Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        playerController = GetComponent<ControllerRestricted>();
        if (playerController == null)
        {
            playerController = this.gameObject.AddComponent<ControllerRestricted>();
        }
    }
    private void FixedUpdate()
    {
        //Update Player position
        UpdateInput();
        rb2D.MovePosition(rb2D.position + direction * speed * Time.fixedDeltaTime);
        //direction.Normalize();

        //ground check
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        //Flip player
        if (facingRight == false && playerController.keyDirection.x > 0 || facingRight == true && playerController.keyDirection.x < 0)
        {
            Flip();
        }

    }
    void Update()
    {

    }
    protected virtual void UpdateInput()
    {
        if (playerController.IsKeyDown)
        {
            this.direction = playerController.direction;
        }

        else
        {
            this.direction = Vector3.zero;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void Jump()
    {
        // this.direction.y = playerController.direction.y;
       // rb2D.MovePosition(rb2D.position + direction * speed * Time.fixedDeltaTime);

        //if (onGround == true)
        //{
        //    extraJumps = extraJumpValue;
        //}

        //if (Input.GetKey("up") && extraJumps > 0)
        //{
        //    this.direction.y = playerController.direction.y * jumpForce;
        //    extraJumps--;
        //}
        //else if (Input.GetKey("up") && extraJumps == 0 && onGround == true)
        //{
        //    this.direction.y = playerController.direction.y * jumpForce;
        //}
      

    }
}
