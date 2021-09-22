using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightning : Turret
{
    private Enemy_AI TargetEnemy;
    public ParticleSystem ps;
    public float Damage, DamageTicks;

    private void Update()
    {
        if (fireCountdown <= 0f)
        {
            StartCoroutine(DamageTick());
            fireCountdown = 0.5f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }
    IEnumerator DamageTick()
    {
        int counter = 0;

        while (counter < DamageTicks)
        {
            TargetEnemy.TakeDamage(Damage);
            counter++;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
