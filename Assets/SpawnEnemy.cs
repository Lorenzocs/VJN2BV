using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Enemy2 prefabEnemy;
    public Transform[] positionSpawns;
    public float timeSpawn;
    public float timeSpawnInit;
    public bool canSpawn;
    public int enemyCount;
    void Update()
    {
        if (canSpawn == true)
        {
            if (enemyCount< 3)//varaible Limite
            {

                if (timeSpawn <= 0)
                {
                    Vector3 position = positionSpawns[Random.Range(0, positionSpawns.Length)].position;
                    Enemy2 myEnemy= Instantiate(prefabEnemy, position, transform.rotation);
                    myEnemy.mySpawn = this;
                    timeSpawn = timeSpawnInit;
                    enemyCount++;
                }
                else
                {
                    timeSpawn -= Time.deltaTime;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Shooter player = collision.GetComponent<Shooter>();
        if (player != null)
        {
            canSpawn = true;
        }
    }
}
