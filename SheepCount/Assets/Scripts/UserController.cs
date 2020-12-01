using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    float jumpCoolDown;
    public float moveInput;
    public float jumpPower;
    public int extraJumps;
    public float speed;
    public int jumpCount;

    //Ground check for jump
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    public float groundRadius;
    public bool onGround;

    private void Start()
    {
        extraJumps = 2;
    }

    private void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown("up"))
        {
            Jump();
        }
        CheckifOnGround();

    }

    private void FixedUpdate()
    {

    }

    void Jump()
    {
        if (onGround || jumpCount < extraJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpCount++;
        }

    }

    void CheckifOnGround()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer))
        {
            onGround = true;
            jumpCount = 0;
            jumpCoolDown = Time.time + 0.2f;
        }
        else if (Time.time < jumpCoolDown)
        {
            onGround = true;
        }
        else
        { onGround = false; }
    }
}
