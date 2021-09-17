using UnityEngine;

public class LaserTurret : Rotating
{
    private Enemy_AI targetEnemy;

    public LineRenderer lineRenderer;

    public int damageOverTime = 30;
    public float slowPct = .5f;

    public void UpdateLaser()
    {
        if (target == null)
        {
            if (lineRenderer.enabled)
                lineRenderer.enabled = false;
            return;
        } 
        Laser();
    }

    private void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPct);

        if (!lineRenderer.enabled)
            lineRenderer.enabled = true;

        lineRenderer.SetPosition(1, firepoint.position);
        lineRenderer.SetPosition(2, target.position);
    }
}