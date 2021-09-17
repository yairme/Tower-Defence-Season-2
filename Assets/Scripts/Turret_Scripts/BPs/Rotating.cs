using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : Turret
{
    public void FixUpdate()
    {
        if (target == null)
            return;
        //target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, 0f, rotation.z);
    }
}
