using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public GameObject ufoEnemy;
    public GameObject spikerEnemy;
    public float enemySpawnDelay = 1f;

    public void SpawnBasicEnemy()
    {
        GameObject currentEnemy=Instantiate(ufoEnemy);
        currentEnemy.transform.position = gameObject.transform.position;
        Debug.Log("Spawned basic enemy");
    }

    public void SpawnSpikerEnemy()
    {
        GameObject currentEnemy = Instantiate(spikerEnemy);
        currentEnemy.transform.position = gameObject.transform.position;
        Debug.Log("Spawned spiker enemy");
    }

    public void SpawnBasicEnemiesFromShip(int enemyNum)
    {
        for (int i=0;i<enemyNum;i++) {
            //spawns basic enemy every second
            Invoke("SpawnBasicEnemy", enemySpawnDelay*i);
        }
    }
}
