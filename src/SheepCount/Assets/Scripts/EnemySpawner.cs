using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public PlatformPooler enemyPool;
    public float respawnTime;
    private Vector3 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(Wave());
    }

    public void SpawnEnemy(Vector2 startPos)
    {
        //create enemy in the world at random
        GameObject enemy = enemyPool.GetPooledObject();
        enemy.transform.position = startPos;
        enemy.SetActive(true);
    }

    IEnumerator Wave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            //spawn at the spawner point but with restrictions and randomness
            SpawnEnemy(new Vector2(transform.position.x + Random.Range(-screenBounds.x, screenBounds.x), transform.position.y + (screenBounds.y * 2)));
        }

    }


}
