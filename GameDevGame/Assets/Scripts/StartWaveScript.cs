using UnityEngine;
using UnityEngine.UI;
public class StartWaveScript : MonoBehaviour
{
    public GameObject enemyShips;
    public string enemyTag = "Enemy";
    public Text childText;

    public string inTheMiddleOfWaveText ="WAVE INCOMING!";
    public string startWaveText = "START WAVE";

    private bool inTheMiddleOfWave=false;
    private float waveCountDown = 1f;

    public void StartWave()
    {
        if (!inTheMiddleOfWave)
        {
            inTheMiddleOfWave = true;
            childText.text = inTheMiddleOfWaveText;
            waveCountDown = 1f;
            EnemyWaveSpawner[] enemyMotherShips = enemyShips.GetComponentsInChildren<EnemyWaveSpawner>();

            SpawnWave(Player.wave, enemyMotherShips);

            Player.wave++;
        }
    }

    public void SpawnWave(int waveNum, EnemyWaveSpawner[] enemyMotherShips)
    {
        //TODO make this switch, balance issues etc.
        enemyMotherShips[0].SpawnBasicEnemiesFromShip(waveNum*2);
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
}
