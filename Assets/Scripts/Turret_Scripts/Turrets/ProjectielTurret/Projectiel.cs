using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiel : Turret
{
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, 0f, rotation.z);

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
