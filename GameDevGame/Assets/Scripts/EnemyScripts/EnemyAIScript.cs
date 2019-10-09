using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIScript : MonoBehaviour
{
    [Header("Attributes")]
    public GameObject targetPlanet;
    public float moveSpeed=20f;
    public int hitPoints = 10;
    public int moneyReward = 10;

    [Header("Setup fields")]
    public float collisionDistance = 10f;

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
        Player.HP -= 1;
        Debug.Log("Enemy hit player");
        Destroy(gameObject);
    }

    public void takeDamage(int Damage)
    {
        hitPoints -= Damage;
        if (hitPoints <= 0)
        {
            die();
        }
    }

    public void die()
    {
        Player.monies += moneyReward;
        Destroy(gameObject);
    }
}
