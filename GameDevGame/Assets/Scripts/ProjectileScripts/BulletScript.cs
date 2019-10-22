using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 200f;
    public float bulletDamage = 5f;

    private Transform target;

    public void setTargetTo(Transform _target)
    {
        target = _target;
    }
    public void setDamage(float damage)
    {
        bulletDamage = damage;
    }
    
    void Update()
    {
        if(target != null)
        {
            Vector3 direction = target.position - transform.position;
            float distanceToMove = bulletSpeed * Time.deltaTime;

            if(direction.magnitude <= distanceToMove)
            {
                //Bullet hit target
                HitTarget();
                return;
            }

            transform.Translate(direction.normalized * distanceToMove, Space.World);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void HitTarget()
    {
        Debug.Log("Target hit");
        GameObject enemy = target.gameObject;
        enemy.GetComponent<EnemyAIScript>().takeDamage(bulletDamage);
        Destroy(gameObject);
    }
}
