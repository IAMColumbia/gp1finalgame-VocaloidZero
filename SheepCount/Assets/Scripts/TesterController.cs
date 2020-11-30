using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterController : MonoBehaviour
{
    //jump conditions
    [SerializeField] Rigidbody2D rb;
    float jumpCoolDown;
    public float moveX;
    public float jumpPower;
    public int extraJumps;
    public float speed;
    public int jumpCount;

    //Ground check for jump
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    public float groundRadius;
    public bool onGround;

    public float jumpHeight;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("right"))
        {
            rb.velocity = new Vector2(moveX, rb.velocity.y);
        }
        if (Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-moveX, rb.velocity.y);
        }
        if (Input.GetKeyDown("up") && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }
}
