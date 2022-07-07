using UnityEngine;

public class LaserTurret : Turret
{
    public LineRenderer lineRenderer;

    public int damageOverTime = 30;
    public float slowPct = .5f;

    public override void Update()
    {
        if (TargetEnemy == null || Target == null)
        {
            if (lineRenderer.enabled)
                lineRenderer.enabled = false;
            return;
        }

        Laser();
    }

    private void Laser()
    {
        TargetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        TargetEnemy.Slow(slowPct);

        if (!lineRenderer.enabled)
            lineRenderer.enabled = true;

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, Target.position);
    }
    
    protected override void LockOnTarget()
    {
        if (Target == null)
            return;

        Debug.DrawLine(transform.position, Target.position);
    }
}