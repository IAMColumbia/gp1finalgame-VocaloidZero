using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float bounceBack;
    private float stagger;


    // Start is called before the first frame update
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                stagger = transform.position.x + Random.Range(-bounceBack, bounceBack);
                other.transform.position = new Vector3(stagger, transform.position.y, transform.position.z);
                gameObject.SetActive(false);
                break;

            //case "Floor":
            //    gameObject.SetActive(false);
            //    break;
        }
    }
}
