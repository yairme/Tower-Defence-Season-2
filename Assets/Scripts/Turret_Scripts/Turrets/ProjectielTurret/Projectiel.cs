using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiel : Turret
{
    
    [SerializeField] protected GameObject bulletPrefab;
    
    public override void Update()
    {
        base.Update();
        
        LockOnTarget();

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = _fireCountdown / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        var bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var bullet = bulletGo.GetComponent<Bullet_BP>();

        if (bullet != null && Vector3.Distance(Target.transform.position, transform.position) < range)
            bullet.Seek(Target);
    }
}
