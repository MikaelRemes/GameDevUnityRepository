using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public GameObject enemy;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        GameObject currentEnemy=Instantiate(enemy);
        currentEnemy.transform.position = gameObject.transform.position;
        Debug.Log("Spawned enemy");
    }
}
