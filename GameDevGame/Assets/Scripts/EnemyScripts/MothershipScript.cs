using UnityEngine;

public class MothershipScript : MonoBehaviour
{
    public GameObject ufoEnemy;
    public GameObject spikerEnemy;
    public GameObject stealthEnemy;
    public GameObject superUfoEnemy;
    public GameObject hyperUfoEnemy;
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

    void SpawnStealthEnemy()
    {
        GameObject currentEnemy = Instantiate(stealthEnemy);
        currentEnemy.transform.position = gameObject.transform.position;
        Debug.Log("Spawned stealth enemy");
    }

    void SpawnSuperUfoEnemy()
    {
        GameObject currentEnemy = Instantiate(superUfoEnemy);
        currentEnemy.transform.position = gameObject.transform.position;
        Debug.Log("Spawned super ufo enemy");
    }

    public void SpawnHyperUfoEnemy()
    {
        GameObject currentEnemy = Instantiate(hyperUfoEnemy);
        currentEnemy.transform.position = gameObject.transform.position;
        Debug.Log("Spawned world ending enemy");
    }

    public void SpawnEnemiesFromShip(int ufoEnemyNum, int spikerEnemyNum, int stealthEnemyNum, int SuperUfoEnemyNum)
    {
        for (int i = 0; i < ufoEnemyNum; i++)
        {
            Invoke("SpawnBasicEnemy", enemySpawnDelay * i);
        }
        for (int i = 0; i < spikerEnemyNum; i++)
        {
            Invoke("SpawnSpikerEnemy", enemySpawnDelay * i + 0.15f);
        }
        for (int i = 0; i < stealthEnemyNum; i++)
        {
            Invoke("SpawnStealthEnemy", enemySpawnDelay * i + 0.25f);
        }
        for (int i = 0; i < SuperUfoEnemyNum; i++)
        {
            Invoke("SpawnSuperUfoEnemy", enemySpawnDelay * i + 0.3f);
        }
    }

    public void QuickSpawnEnemiesFromShip(int ufoEnemyNum, int spikerEnemyNum, int stealthEnemyNum, int SuperUfoEnemyNum)
    {
        for (int i = 0; i < ufoEnemyNum; i++)
        {
            Invoke("SpawnBasicEnemy", enemySpawnDelay * i/2);
        }
        for (int i = 0; i < spikerEnemyNum; i++)
        {
            Invoke("SpawnSpikerEnemy", enemySpawnDelay * i / 2 + 0.05f);
        }
        for (int i = 0; i < stealthEnemyNum; i++)
        {
            Invoke("SpawnStealthEnemy", enemySpawnDelay * i / 2 + 0.1f);
        }
        for (int i = 0; i < SuperUfoEnemyNum; i++)
        {
            Invoke("SpawnSuperUfoEnemy", enemySpawnDelay * i / 2 + 0.15f);
        }
    }
}
