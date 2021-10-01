using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiel : Turret
{
    private void Update()
    {

        LockOnTarget();

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    public void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        Bullet_BP bullet = bulletGO.GetComponent<Bullet_BP>();

        if (bullet != null)
            bullet.Seek(target);
    }
}
