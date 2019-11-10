using UnityEngine;
using UnityEngine.UI;
public class StartWaveScript : MonoBehaviour
{
    [Header("Setup fields")]
    public GameObject enemyMotherShip;
    public Vector3[] enemyMotherShipSpawns;
    public string enemyTag = "Enemy";
    public string mothershipTag = "Mothership";
    public Text childText;
    public string inTheMiddleOfWaveText ="WAVE INCOMING!";
    public string startWaveText = "START WAVE";

    public bool inTheMiddleOfWave=false;

    private float waveCountDown = 1f;
    private int MotherShips = 0;

    private GameObject currentMothership;

    private void Start()
    {
        SpawnMothership();
      //  InvokeRepeating("SpawnMothership", 1.0f, 1.0f);

    }

    public void SpawnMothership()
    {
        //Count how many motherships there are on game
        MotherShips = MotherShips + 1;

        //All new MothershipHandle instantiates at point ZERO
        //Mothership rotation vs planet is handled in MothershipScript on Awake
        currentMothership = Instantiate(enemyMotherShip, new Vector3(0, 0, 0), transform.rotation) as GameObject;
     }

    public void StartWave()
    {
        if (!inTheMiddleOfWave)
        {
            inTheMiddleOfWave = true;
            childText.text = inTheMiddleOfWaveText;
            waveCountDown = 1f;

            GameObject[] motherships = GameObject.FindGameObjectsWithTag(mothershipTag);


            SpawnWave(Player.wave, motherships);

            Player.wave++;
        }
    }

    void Update()
    {
        waveCountDown -= Time.deltaTime;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        if (enemies.Length <= 0  && waveCountDown<=0)
        {
            inTheMiddleOfWave = false;
            childText.text=startWaveText;
        }
    }

    public void SpawnWave(int waveNum, GameObject[] enemyMotherShips)
    {
        //TODO: balancing
        switch (waveNum)
        {
            case 1:
                enemyMotherShips[0].GetComponent<MothershipScript>().SpawnEnemiesFromShip(2,0,0,0);
                break;
            case 2:
                enemyMotherShips[0].GetComponent<MothershipScript>().SpawnEnemiesFromShip(5, 1, 0, 0);
                break;
            case 3:
                enemyMotherShips[0].GetComponent<MothershipScript>().SpawnEnemiesFromShip(3, 3, 0, 0);
                SpawnMothership();
                break;
            case 4:
                enemyMotherShips[0].GetComponent<MothershipScript>().QuickSpawnEnemiesFromShip(8, 0, 0, 0);
                enemyMotherShips[1].GetComponent<MothershipScript>().QuickSpawnEnemiesFromShip(8, 0, 0, 0);
                enemyMotherShips[0].GetComponent<MothershipScript>().SpawnEnemiesFromShip(0, 3, 0, 0);
                enemyMotherShips[1].GetComponent<MothershipScript>().SpawnEnemiesFromShip(0, 3, 0, 0);
                break;
            case 5:
                enemyMotherShips[0].GetComponent<MothershipScript>().QuickSpawnEnemiesFromShip(10, 0, 0, 0);
                enemyMotherShips[1].GetComponent<MothershipScript>().QuickSpawnEnemiesFromShip(10, 0, 0, 0);
                enemyMotherShips[0].GetComponent<MothershipScript>().SpawnEnemiesFromShip(0, 0, 3, 0);
                enemyMotherShips[1].GetComponent<MothershipScript>().SpawnEnemiesFromShip(0, 0, 3, 0);
                break;
            case 6:
                enemyMotherShips[0].GetComponent<MothershipScript>().SpawnEnemiesFromShip(0, 0, 0, 1);
                SpawnMothership();
                break;
            case 7:
                enemyMotherShips[0].GetComponent<MothershipScript>().SpawnEnemiesFromShip(0, 8, 5, 0);
                enemyMotherShips[1].GetComponent<MothershipScript>().SpawnEnemiesFromShip(0, 0, 0, 1);
                enemyMotherShips[2].GetComponent<MothershipScript>().SpawnEnemiesFromShip(0, 8, 5, 0);
                break;
            case 8:
                enemyMotherShips[0].GetComponent<MothershipScript>().SpawnEnemiesFromShip(0, 0, 0, 3);
                enemyMotherShips[1].GetComponent<MothershipScript>().SpawnEnemiesFromShip(0, 0, 0, 3);
                enemyMotherShips[2].GetComponent<MothershipScript>().SpawnEnemiesFromShip(0, 0, 0, 3);
                break;
            case 9:
                enemyMotherShips[0].GetComponent<MothershipScript>().SpawnHyperUfoEnemy();
                break;
            case 10:
                enemyMotherShips[0].GetComponent<MothershipScript>().QuickSpawnEnemiesFromShip(50, 50, 50, 25);
                enemyMotherShips[0].GetComponent<MothershipScript>().SpawnHyperUfoEnemy();
                enemyMotherShips[1].GetComponent<MothershipScript>().QuickSpawnEnemiesFromShip(50, 50, 50, 25);
                enemyMotherShips[1].GetComponent<MothershipScript>().SpawnHyperUfoEnemy();
                enemyMotherShips[2].GetComponent<MothershipScript>().QuickSpawnEnemiesFromShip(50, 50, 50, 25);
                enemyMotherShips[2].GetComponent<MothershipScript>().SpawnHyperUfoEnemy();
                break;
            default:
                break;
        }
    }
}
