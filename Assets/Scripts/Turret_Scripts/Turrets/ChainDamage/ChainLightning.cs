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
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var em = ps.emission;

        if (target == null)
        {
            if (em.enabled)
                em.enabled = false;
            return;
        }

        if (fireCountdown <= 0f)
        {
            em.enabled = true;
            em.rateOverTime = 20.0f;
            em.SetBursts(
                new ParticleSystem.Burst[]{
                new ParticleSystem.Burst(2.0f, 9),
                });
            LightningStrike();
            fireCountdown = 0.5f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void LightningStrike()
    {
        TargetEnemy.TakeDamage(Damage);
    }
}
