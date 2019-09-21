using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIScript : MonoBehaviour
{
    public GameObject targetPlanet;
    public float speed=0.05f;

    void Start()
    {
        //move enemy towards player at speed x
        //if speed can be slowed or planet can move, move this method to update
        gameObject.GetComponent<Rigidbody>().velocity =
            (targetPlanet.transform.position - gameObject.transform.position) * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.Equals(targetPlanet))
        {
            //TODO: deal damage to player
            Destroy(gameObject);
        }
    }
}
