using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIScript : MonoBehaviour
{
    public GameObject targetPlanet;
    public float speed=0.05f;
    public int hitPoints = 10;
    public int moneyReward = 10;

    void Start()
    {
        //necessary to find target when spawned via script
        targetPlanet = GameObject.FindGameObjectWithTag("Planet");

        //move enemy towards player at speed x
        //if speed can be slowed or planet can move, move this method to update
        gameObject.GetComponent<Rigidbody>().velocity =
            (targetPlanet.transform.position - gameObject.transform.position) * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.Equals(targetPlanet))
        {
            Player.HP -= 1;
            Debug.Log("Enemy hit player");
            Destroy(gameObject);
        }
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
