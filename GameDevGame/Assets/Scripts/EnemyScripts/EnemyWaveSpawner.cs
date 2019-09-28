using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public GameObject enemy;
    public float enemySpawnDelay = 0.5f;

    public void SpawnBasicEnemy()
    {
        GameObject currentEnemy=Instantiate(enemy);
        currentEnemy.transform.position = gameObject.transform.position;
        Debug.Log("Spawned basic enemy");
    }

    public void SpawnBasicEnemiesFromShip(int enemyNum)
    {
        for (int i=0;i<enemyNum;i++) {
            //spawns basic enemy every second
            Invoke("SpawnBasicEnemy", i);
        }
    }
}
