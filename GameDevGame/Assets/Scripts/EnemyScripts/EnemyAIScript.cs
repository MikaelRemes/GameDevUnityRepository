using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIScript : MonoBehaviour
{
    [Header("Attributes")]
    public float moveSpeed=20f;
    public float hitPoints = 10f;
    public int moneyReward = 10;
    public int playerDamage = 1;

    [Header("Setup fields")]
    public GameObject targetPlanet;
    public float collisionDistance = 10f;
    public GameObject explosionEffect;

    [Header("Setup fields for ufo spawner")]
    public bool spawnUfoAttackers = false;
    public float spawnUfoRate = 1.5f;
    public GameObject ufoAttacker;
    public GameObject spawnUfoEffect;

    private float slowedSpeedPrentage = 1f;
    private float slowCountDown = 0f;
    private float spawnUfoCountDown = 3f;

    void Start()
    {
        //necessary to find target when spawned via script
        targetPlanet = GameObject.FindGameObjectWithTag("Planet");
    }

    void Update()
    {
        //move enemy towards player at speed x
        Vector3 direction = targetPlanet.transform.position - transform.position;
        float distanceToMove = moveSpeed * Time.deltaTime;

        //enemy head towards enemy
        Quaternion lookDirection = Quaternion.LookRotation(direction);
        transform.rotation = lookDirection;

        //if enemy is slowed, reduce ms
        if (slowCountDown > 0)
        {
            distanceToMove = distanceToMove * slowedSpeedPrentage;
        }
        slowCountDown -= Time.deltaTime;

        if (spawnUfoAttackers) {
            //spawn ufo every x seconds
            if (spawnUfoCountDown < 0)
            {
                spawnUfoCountDown = spawnUfoRate;
                SpawnUfoAttacker();
            }
            spawnUfoCountDown -= Time.deltaTime;
        }

        if (direction.magnitude - collisionDistance <= distanceToMove)
        {
            //Enemy reached player's planet
            HitPlayer();
            return;
        }

        transform.Translate(direction.normalized * distanceToMove, Space.World);
    }
    
    void HitPlayer()
    {
        Player.HP -= playerDamage;
        Debug.Log("Enemy hit player");
        GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(explosion, 1f);
        Destroy(gameObject);
    }

    public void takeDamage(float Damage)
    {
        hitPoints -= Damage;
        if (hitPoints <= 0)
        {
            die();
        }
    }

    public void slow(float duration, float prentageAmount)
    {
        if(prentageAmount < 1f) slowedSpeedPrentage = 1f - prentageAmount;
        slowCountDown = duration;
    }

    public void die()
    {
        Player.monies += moneyReward;
        Destroy(gameObject);
    }

    private void SpawnUfoAttacker()
    {
        GameObject currentEnemy = Instantiate(ufoAttacker);
        GameObject effectSpawn = Instantiate(spawnUfoEffect);
        //spawns ufo attacker in a random position near enemy
        Vector3 positionOfUfo = Random.insideUnitSphere * 25 + gameObject.transform.position;
        currentEnemy.transform.position = positionOfUfo;
        effectSpawn.transform.position = positionOfUfo;
    }
}
