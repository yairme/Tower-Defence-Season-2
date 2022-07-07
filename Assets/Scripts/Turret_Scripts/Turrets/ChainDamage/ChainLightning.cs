using System.Collections;
using UnityEngine;

public class ChainLightning : Turret
{
    [Header("Lightning Tower Atributes")]
    public ParticleSystem ps;

    [SerializeField] private float damage; 
    [SerializeField] private float damageTicks;

    public override void Update()
    {
        base.Update(); 
        Lightning();
    }

    private void Lightning()
    {
        if (fireCountdown <= 0f)
        {
            StartCoroutine(DamageTick());
            fireCountdown = _fireCountdown / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    private IEnumerator DamageTick()
    {
        var counter = 0;

        while (counter < damageTicks && TargetEnemy != null)
        {
            DoDamage();
            counter++;
            yield return new WaitForSeconds(2f);
        }
    }

    private void DoDamage()
    {
        TargetEnemy.TakeDamage(damage);
    }
}
