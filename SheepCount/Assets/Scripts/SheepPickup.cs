using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepPickup : MonoBehaviour
{
    private ScoreManager sm;
    public AudioSource pickupNoise;
    public int assignScore;


    // Start is called before the first frame update
    void Start()
    {
        pickupNoise = GetComponent<AudioSource>();
        sm = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    switch (other.gameObject.tag)
    //    {
    //        case "Player":
    //            //add 1 point to score
    //            sm.AddScore(assignScore);
    //            pickupNoise.Play();
    //            gameObject.SetActive(false);

    //            break;

    //    }
    //}
    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                //add 1 point to score
                sm.AddScore(assignScore);
                pickupNoise.Play();
                gameObject.SetActive(false);

                break;

        }
    }
}
