using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //[SerializeField]
    //private float xBound;
    //[SerializeField]
    //private float[] xPos;
    //[SerializeField]
    //private GameObject[] enemies;
    //[SerializeField]
    //private Wave wave;
    public PlatformPooler enemyPool;
    public float respawnTime;
    private Vector3 screenBounds;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        //player = FindObjectOfType<Player>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(Wave());
    }

    public void SpawnEnemy()
    {
        //create enemy in the world at random
        GameObject enemy = enemyPool.GetPooledObject();
        enemy.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2);
        enemy.SetActive(true);
    }

    IEnumerator Wave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }

    }


}
