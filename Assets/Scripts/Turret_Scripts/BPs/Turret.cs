using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    protected Transform target;

    [Header("Attributes")]
    public float range;
    public float fireRate;
    protected float fireCountdown, damageOvertime;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    [Header("Setup Fields")]
    public Transform PartToRotate;
    public Transform firepoint;
    public float turnspeed = 10f;
    public GameObject bulletprefab;
    public void Start()
    { 
      InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    // Update is called once per frame
    public void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float ShortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < ShortestDistance)
            {
                ShortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && ShortestDistance <= range / 1)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, range / 1);
    }
}
