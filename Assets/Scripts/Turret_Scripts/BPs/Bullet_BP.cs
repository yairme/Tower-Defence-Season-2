using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_BP : MonoBehaviour
{
    protected Transform target;
    public int damage;
    public float speed;

    [Header("For Rockets")]
    public float Explosion;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    protected void Damage(Transform enemy)
    {
        Enemy_AI EN = enemy.GetComponent<Enemy_AI>();

        if (EN != null)
        {
            EN.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }

    protected void Update()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed / 1 * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    protected void HitTarget()
    {
        if (Explosion > 0)
        {
        Explode(transform.position, Explosion);
        }
        else
        {
            Damage(target);
        }
    }
    protected void Explode(Vector3 center, float radius)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);
        foreach (Collider2D collider in hitColliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, Explosion);
    }
}
