using UnityEngine;

public class MissileScript : MonoBehaviour
{
    public float missileSpeed = 35f;
    public float missileAcceleration = 10f;

    public float explosionRadius = 20f;
    public int missileDirectDamage = 25;
    public int missileAoeDamage = 25;

    public string enemyTag = "Enemy";
    public GameObject explosionVisual;

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
                //Bullet hit target
                HitTarget();
                return;
            }

            transform.Translate(direction.normalized * distanceToMove, Space.World);
        }
        else
        {
            //TODO: search new nearest target, if none, then explode
            Explode();
            return;
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
}

