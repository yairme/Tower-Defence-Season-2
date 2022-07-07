using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class Bullet_BP : MonoBehaviour
{
    private Transform target;
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    
    [Header("For Rockets")]
    [SerializeField] private float explosion;

    public void Seek(Transform target)
    {
        this.target = target;
    }

    protected void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        
        var dir = target.position - transform.position;
        var distanceThisFrame = speed / 1 * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
        transform.right = target.position - transform.position;
    }

    private void HitTarget()
    {
        if (explosion > 0)
        {
            Explode(transform.position, explosion);
        }
        else
        {
            Damage(target);
        }
    }

    private void Explode(Vector3 center, float radius)
    {
        var hitColliders = Physics2D.OverlapCircleAll(center, radius);
        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }
    }
    
    private void Damage(Transform enemy)
    {
        var EN = enemy.GetComponent<Enemy_AI>();

        if (EN == null) return;
        EN.TakeDamage(damage);
        Destroy(gameObject);
    }


    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosion);
    }
}
