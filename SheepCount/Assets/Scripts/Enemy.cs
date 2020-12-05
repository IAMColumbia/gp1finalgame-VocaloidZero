using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public AudioSource hit;
    public float speed;
    public float bounceBack;
    private float stagger;


    private void Awake()
    {
        hit = GetComponent<AudioSource>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //falling obstable
        transform.position += Vector3.down * speed * Time.fixedDeltaTime;
    }

    //collide conditions
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    switch (other.gameObject.tag)
    //    {
    //        case "Player":
    //            hit.Play();
    //            stagger = transform.position.x + Random.Range(-bounceBack, bounceBack);
    //            other.transform.position = new Vector3(stagger, transform.position.y, transform.position.z);
    //            gameObject.SetActive(false);
    //            break;

    //        //case "Floor":
    //        //    gameObject.SetActive(false);
    //        //    break;
    //    }
    //}

    void OnCollisionEnter2D(Collision2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Player":
                hit.Play();
                stagger = transform.position.x + Random.Range(-bounceBack, bounceBack);
                coll.transform.position = new Vector3(stagger, transform.position.y, transform.position.z);
                gameObject.SetActive(false);
                break;

                //case "Floor":
                //    gameObject.SetActive(false);
                //    break;
        }
    }

}
