using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public GameObject enemy;

    public void SpawnBasicEnemy()
    {
        GameObject currentEnemy=Instantiate(enemy);
        currentEnemy.transform.position = gameObject.transform.position;
        Debug.Log("Spawned basic enemy");
    }
}
