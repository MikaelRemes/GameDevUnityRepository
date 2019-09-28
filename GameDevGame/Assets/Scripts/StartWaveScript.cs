using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWaveScript : MonoBehaviour
{
    public GameObject enemyShips;

    public void StartWave()
    {
        EnemyWaveSpawner[] enemyMotherShips = enemyShips.GetComponentsInChildren<EnemyWaveSpawner>();

        SpawnWave(Player.wave, enemyMotherShips);

        Player.wave++;
    }

    public void SpawnWave(int waveNum, EnemyWaveSpawner[] enemyMotherShips)
    {
        //TODO make this switch, balance issues etc.
        enemyMotherShips[0].SpawnBasicEnemiesFromShip(waveNum*2);
    }


}
