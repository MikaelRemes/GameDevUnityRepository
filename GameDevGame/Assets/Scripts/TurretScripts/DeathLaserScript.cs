using UnityEngine;

public class DeathLaserScript : MonoBehaviour
{
    [Header("Attributes")]
    public float range = 300f;
    public float fireRatePerSec = 0.5f;
    public int laserDamage = 1000;

    [Header("Setup fields")]
    public string enemyTag = "Enemy";
    public Transform rotateAxis;
    public Transform firePoint;
    public LineRenderer laserEffect;

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

        //TODO: use physics.raycast to check that turret has a visual to enemy (planet or moon wont obstruct its view)
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
        GameObject enemy = target.gameObject;
        enemy.GetComponent<EnemyAIScript>().takeDamage(laserDamage);
        
        laserEffect.SetPosition(0, firePoint.position);
        laserEffect.SetPosition(1, target.position);
        Invoke("resetLaser", 0.3f);
    }

    public void resetLaser()
    {
        laserEffect.SetPosition(0, firePoint.position);
        laserEffect.SetPosition(1, firePoint.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 directionOfEnemy = target.position - transform.position;
            Quaternion lookDirection = Quaternion.LookRotation(directionOfEnemy);
            rotateAxis.rotation = lookDirection;


            if (fireCountDown <= 0)
            {
                Shoot(target);
                fireCountDown = 1f / fireRatePerSec;
            }

            fireCountDown -= Time.deltaTime;

        }
    }
}
