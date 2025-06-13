using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int enemyKilled;
    public int targetKill;


    public void EnemyKill()
    {
        enemyKilled++;
        if (enemyKilled >= targetKill)
        {
            SpawnEnemy[] spawns = FindObjectsOfType<SpawnEnemy>();
            for (int i = 0; i < spawns.Length; i++)
            {
                print("Entre");
                spawns[i].gameObject.SetActive(false);
            }

            Enemy2[] enemies = FindObjectsOfType<Enemy2>();
            for (int i = 0; i < spawns.Length; i++)
            {
                print("Entre2");
                enemies[i].gameObject.SetActive(false);
            }
            print("GANASTE!");
        }
    }


}
