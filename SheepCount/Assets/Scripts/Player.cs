using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerState { Dead, Playing }
    public PlayerState State { get; set; }

    public Vector2 direction;
    public float speed;
    private bool facingRight = false;

    //Restricting x boundries
    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;

    //referances
    UserController playerController;
    public Rigidbody2D rb2D;
    private ResetSceneHandler endGame;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        endGame = FindObjectOfType<ResetSceneHandler>();

        playerController = GetComponent<UserController>();
        if (playerController == null)
        {
            playerController = this.gameObject.AddComponent<UserController>();
        }

        GetCameraXBoundries();

        this.State = PlayerState.Playing;
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

        }

    }

}
