using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_BP : MonoBehaviour
{
    protected Transform target;
    public int damage;
    public float speed;

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
}
