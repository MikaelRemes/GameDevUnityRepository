using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseTurretScript : MonoBehaviour
{
    [Header("Attributes")]
    public float range = 60f;
    public float pulseDamage = 10f;
    public float fireRatePerSec = 0.20f;

    [Header("Setup fields")]
    public string enemyTag = "Enemy";
    public Transform firePoint;
    public GameObject pulseEffect;

    private Transform target;
    private float fireCountDown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Shoot(Transform target)
    {
        Collider[] objectsHit = Physics.OverlapSphere(firePoint.position, range);

        foreach (Collider c in objectsHit)
        {
            if (c.tag.Equals(enemyTag))
            {
                GameObject enemy = c.gameObject;
                enemy.GetComponent<EnemyAIScript>().takeDamage(pulseDamage);
            }
        }

        GameObject fireParticles = Instantiate(pulseEffect, transform.position, transform.rotation);
        Destroy(fireParticles, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {

            if (fireCountDown <= 0)
            {
                Shoot(target);
                fireCountDown = 1f / fireRatePerSec;
            }

            fireCountDown -= Time.deltaTime;

        }
    }
}
