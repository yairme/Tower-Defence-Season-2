using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightning : Turret
{
    private Enemy_AI targetEnemy;
    [Header("Lightning Tower Atributes")]
    public ParticleSystem ps;
    public float Damage, DamageTicks;

    protected void LightningUpdate()
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
            targetEnemy.TakeDamage(Damage * Time.deltaTime);
            counter++;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
