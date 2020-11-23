using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 direction;
    public float speed;
    public float jumpForce;
    private bool facingRight = false;

    //Check if on ground
    private bool onGround;
    public Transform groundCheck;
    public float groundRadius;
    public LayerMask whatIsGround;

    PlayerController playerController;
    private Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        if (playerController == null)
        {
            playerController = this.gameObject.AddComponent<PlayerController>();
        }
    }
    private void FixedUpdate()
    {
        //Update Player position
        UpdateInput();
        rb2D.MovePosition(rb2D.position + direction * speed * Time.fixedDeltaTime);

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
        Jump();
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

    void Jump()
    {

    }
}
