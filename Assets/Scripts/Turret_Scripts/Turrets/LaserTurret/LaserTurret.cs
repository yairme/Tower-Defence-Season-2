using UnityEngine;

public class LaserTurret : Turret
{
    public LineRenderer lineRenderer;

    public int damageOverTime = 30;
    public float slowPct = .5f;

    private void Update()
    {
        if (targetEnemy == null || target == null)
        {
            if (lineRenderer.enabled)
                lineRenderer.enabled = false;
            return;
        }

        LockOnTarget();
        Laser();
    }

    private void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPct);

        if (!lineRenderer.enabled)
            lineRenderer.enabled = true;

        lineRenderer.SetPosition(0, firepoint.position);
        lineRenderer.SetPosition(1, target.position);
    }
    public override void LockOnTarget()
    {
        if (target == null)
            return;

        Debug.DrawLine(transform.position, target.position);
    }
}