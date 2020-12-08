using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerState { Dead, Playing }
    public PlayerState State { get; set; }

    //Jumpin
    public float speed;
    private float jumpCoolDown; //time until next jump can be performed
    public float jumpPower; //how high the player jumps
    public int extraJumps; // how many jumps the player can do
    public int jumpCount; //jump tracker
    private bool facingRight = false;

    //Ground Check
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    public float groundRadius;
    public bool onGround;

    //Restricting x boundries for the player
    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;

    //referances
    UserController playerController;
    public AudioSource jumpNoise;
    public Rigidbody2D rb2D;
    private ResetSceneHandler endGame;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        endGame = FindObjectOfType<ResetSceneHandler>();
        jumpNoise = GetComponent<AudioSource>();

        playerController = GetComponent<UserController>();
        if (playerController == null)
        {
            playerController = this.gameObject.AddComponent<UserController>();
        }

        GetCameraXBoundries();

        this.State = PlayerState.Playing;

        extraJumps = 2;
    }

    private void FixedUpdate()
    {
        switch (this.State)
        {
            case PlayerState.Dead:
                Debug.Log("State = Dead");
                endGame.ResetScene();
                break;
            case PlayerState.Playing:
                PlayGame();
               //Debug.Log("State = Playing");
                break;
        }

    }

    private void PlayGame()
    {
        rb2D.velocity = new Vector2(playerController.moveInput * speed, rb2D.velocity.y);

        if (facingRight == false && playerController.moveInput > 0 || facingRight == true && playerController.moveInput < 0)
        {
            Flip();
        }
    }

    void LateUpdate()
    {
        SetCameraXRestrictions();
    }


    void Update()
    {
    }

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
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; 
    }
    private void SetCameraXRestrictions()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        transform.position = viewPos;
    }

    //Reset the scene on fall
    void OnTriggerEnter2D(Collider2D coll)
    {

        switch (coll.gameObject.tag)
        {
            case "Finish":
                this.State = PlayerState.Dead;
                Debug.Log("Reset Scene");
                break;
            case "PickUP":
                
                break;

        }

    }

    public void Jump()
    {
        if (onGround || jumpCount < extraJumps)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpPower);
            jumpCount++;
            jumpNoise.Play();
        }

    }

    public void CheckifOnGround()
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
