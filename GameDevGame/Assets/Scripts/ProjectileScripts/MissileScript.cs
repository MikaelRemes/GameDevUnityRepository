using UnityEngine;

public class MissileScript : MonoBehaviour
{
    [Header("Attributes")]
    public float missileSpeed = 35f;
    public float missileAcceleration = 20f;
    public float explosionRadius = 20f;
    public int missileDirectDamage = 25;
    public int missileAoeDamage = 25;

    [Header("Setup fields")]
    public string enemyTag = "Enemy";
    public GameObject explosionVisual;
    public float newTargetSearchrange = 300f;

    private Transform target;
    private float collisionDistance = 1f;
    
    public void setTargetTo(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            float distanceToMove = missileSpeed * Time.deltaTime;
            missileSpeed += missileAcceleration * Time.deltaTime;

            //missile head towards enemy
            Quaternion lookDirection = Quaternion.LookRotation(direction);
            transform.rotation = lookDirection;

            if (direction.magnitude - collisionDistance <= distanceToMove)
            {
                //Missile hit target
                HitTarget();
                return;
            }

            transform.Translate(direction.normalized * distanceToMove, Space.World);
        }
        else
        {
            //search for new target if current one is destroyed
            UpdateTarget();
            //if no target is found, then explode
            if (target == null)
            {
                Explode();
                return;
            }
        }
    }

    void HitTarget()
    {
        GameObject enemy = target.gameObject;
        enemy.GetComponent<EnemyAIScript>().takeDamage(missileDirectDamage);
        Explode();
    }

    void Explode()
    {
        Collider[] objectsHit;
        if (target != null) objectsHit = Physics.OverlapSphere(target.position, explosionRadius);
        else objectsHit = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider c in objectsHit)
        {
            if (c.tag.Equals(enemyTag))
            {
                GameObject enemy = c.gameObject;
                enemy.GetComponent<EnemyAIScript>().takeDamage(missileAoeDamage);
            }
        }
        GameObject fireParticles = Instantiate(explosionVisual, transform.position, transform.rotation);
        Destroy(fireParticles, 1f);
        Destroy(gameObject);
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

        if (nearestEnemy != null && shortestDistance <= newTargetSearchrange)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
}

