﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWaveScript : MonoBehaviour
{
    public GameObject enemyShips;

    public void StartWave()
    {
        EnemyWaveSpawner[] enemyMotherShips = enemyShips.GetComponentsInChildren<EnemyWaveSpawner>();

        //TODO: spawn a wave, not a single enemy from each ship
        foreach(EnemyWaveSpawner motherShip in enemyMotherShips)
        {
            motherShip.SpawnBasicEnemy();
        }
    }
}
