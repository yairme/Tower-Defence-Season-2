using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    protected Transform Target;
    protected Enemy_AI TargetEnemy;
    protected Enemy_AI[] GroupEnemy;

    [Header("Attributes")]
    [SerializeField] protected float range;
    [SerializeField] protected float fireRate;
    [SerializeField] protected float fireCountdown;
    protected float _fireCountdown;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    [Header("Setup Fields")]
    [SerializeField] protected Transform partToRotate;
    [SerializeField] protected Transform firePoint;

    public void Start()
    {
        _fireCountdown = fireCountdown;
        InvokeRepeating("UpdateTarget", 0f, .5f);
    }

    public virtual void Update()
    {
        if (TargetEnemy == null || Target == null)
        {
            return;
        }
        LockOnTarget();
    }

    // Update is called once per frame
    public void UpdateTarget()
    {
        var enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        var shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;
        foreach (var enemy in enemies)
        {
            var distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (!(distanceToEnemy < shortestDistance)) continue;
            shortestDistance = distanceToEnemy;
            nearestEnemy = enemy;
        }
        if (nearestEnemy != null && shortestDistance <= range / 2)
        {
            Target = nearestEnemy.transform;
            TargetEnemy = nearestEnemy.GetComponent<Enemy_AI>();
        }
        else
        {
            Target = null;
            TargetEnemy = null;
        }
    }

    protected virtual void LockOnTarget()
    {
        if (Target == null) return;
        partToRotate.transform.right = (Target.position - transform.position);
        Debug.DrawLine(transform.position, Target.position);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range / 2);
    }
}
