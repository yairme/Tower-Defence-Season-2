using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightning : Turret
{
    private Enemy_AI targetEnemy;
    [Header("Lightning Tower Atributes")]
    public ParticleSystem ps;
    public float Damage, DamageTicks;

    public IEnumerator DamageTick()
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
