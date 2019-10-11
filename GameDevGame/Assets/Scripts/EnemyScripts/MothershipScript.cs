using UnityEngine;

public class MothershipScript : MonoBehaviour
{
    public GameObject ufoEnemy;
    public GameObject spikerEnemy;
    public GameObject superUfoEnemy;
    public float enemySpawnDelay = 0.8f;

    void SpawnBasicEnemy()
    {
        GameObject currentEnemy=Instantiate(ufoEnemy);
        currentEnemy.transform.position = gameObject.transform.position;
        Debug.Log("Spawned ufo enemy");
    }

    void SpawnSpikerEnemy()
    {
        GameObject currentEnemy = Instantiate(spikerEnemy);
        currentEnemy.transform.position = gameObject.transform.position;
        Debug.Log("Spawned spiker enemy");
    }

    void SpawnSuperUfoEnemy()
    {
        GameObject currentEnemy = Instantiate(superUfoEnemy);
        currentEnemy.transform.position = gameObject.transform.position;
        Debug.Log("Spawned super ufo enemy");
    }

    public void SpawnEnemiesFromShip(int ufoEnemyNum, int spikerEnemyNum, int SuperUfoEnemyNum)
    {
        for (int i = 0; i < ufoEnemyNum; i++)
        {
            Invoke("SpawnBasicEnemy", enemySpawnDelay * i);
        }
        for (int i = 0; i < spikerEnemyNum; i++)
        {
            Invoke("SpawnSpikerEnemy", enemySpawnDelay * i + 0.15f);
        }
        for (int i = 0; i < SuperUfoEnemyNum; i++)
        {
            Invoke("SpawnSuperUfoEnemy", enemySpawnDelay * i + 0.3f);
        }
    }

    public void QuickSpawnEnemiesFromShip(int ufoEnemyNum, int spikerEnemyNum, int SuperUfoEnemyNum)
    {
        for (int i = 0; i < ufoEnemyNum; i++)
        {
            Invoke("SpawnBasicEnemy", enemySpawnDelay * i/2);
        }
        for (int i = 0; i < spikerEnemyNum; i++)
        {
            Invoke("SpawnSpikerEnemy", enemySpawnDelay * i / 2 + 0.05f);
        }
        for (int i = 0; i < SuperUfoEnemyNum; i++)
        {
            Invoke("SpawnSuperUfoEnemy", enemySpawnDelay * i / 2 + 0.1f);
        }
    }
}
