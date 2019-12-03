using UnityEngine;

public class MothershipScript : MonoBehaviour
{
    public GameObject ufoEnemy;
    public GameObject spikerEnemy;
    public GameObject stealthEnemy;
    public GameObject superUfoEnemy;
    public GameObject hyperUfoEnemy;
    public GameObject playerPlanet;
    public LineRenderer enemyDirectionPointerEffect;
    public float enemySpawnDelay = 0.0f; //0.8f;
    public float rotateAroundPlanetSpeed = 1f;

    private GameObject StartWaveSkripti;

    void Start()
    {
        //necessary to find player when spawned via script
        playerPlanet = GameObject.FindGameObjectWithTag("Planet");

        //Find Startwavescript
        StartWaveSkripti = GameObject.Find("StartWaveButton");
    }

    private void Update()
    {
        if (enemyDirectionPointerEffect != null) {
            enemyDirectionPointerEffect.SetPosition(0, transform.position);
            enemyDirectionPointerEffect.SetPosition(1, playerPlanet.transform.position);
        }

        //transform.LookAt(playerPlanet.transform.position);

        if (StartWaveSkripti.GetComponent<StartWaveScript>().inTheMiddleOfWave == true)
        {
            //Move slowly forward closer to planet during wave
            if (transform.localPosition.x > 170)
            {
                transform.localPosition = new Vector3(transform.localPosition.x - 5 * Time.deltaTime, 0, 0);
            }

            //rotate around planet slowly during wave
            transform.parent.RotateAround(playerPlanet.transform.position, Vector3.up, Time.deltaTime * rotateAroundPlanetSpeed);
        }
    }

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
