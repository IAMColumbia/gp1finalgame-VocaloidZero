using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player player;
    public float speed;
    public float bounceBack;

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
                other.transform.position = new Vector3(transform.position.x + bounceBack, transform.position.y, transform.position.z);
                gameObject.SetActive(false);
                break;

            //case "Floor":
            //    gameObject.SetActive(false);
            //    break;
        }
    }
}
