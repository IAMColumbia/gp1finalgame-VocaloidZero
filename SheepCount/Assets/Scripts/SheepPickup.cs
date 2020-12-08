using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepPickup : MonoBehaviour
{
    private ScoreManager sm;
    [SerializeField]
    private AudioClip pickupNoise;
    public int assignScore;


    // Start is called before the first frame update
    void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                //add 1 point to score
                sm.AddScore(assignScore);
                AudioSource.PlayClipAtPoint(pickupNoise, transform.position);
                gameObject.SetActive(false);

                break;

        }
    }
}
