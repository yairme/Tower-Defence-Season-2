using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightning : Turret
{
    [Header("Lightning Tower Atributes")]
    public ParticleSystem ps;
    public float Damage, DamageTicks;

    private void Update()
    {
        if (target == null)
            return;

        LockOnTarget();
        Lightning();
    }

    public void Lightning()
    {
        if (fireCountdown <= 0f)
        {
            StartCoroutine(DamageTick());
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    public IEnumerator DamageTick()
    {
        int counter = 0;

        while (counter < DamageTicks)
        {
            targetEnemy.TakeDamage(Damage);
            counter++;
            yield return new WaitForSeconds(2f);
        }
    }
}
