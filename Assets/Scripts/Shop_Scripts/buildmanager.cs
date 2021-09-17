using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildmanager : MonoBehaviour
{
    [HideInInspector] public buildmanager instance;
    public bool i;

    public bool Bal = false;

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one buildmanager");
            return;
        }
        instance = this;
    }

    public GameObject standardturret;
    public GameObject laserturret;
    public GameObject Missileturret;

    public void Start()
    {
        turrettobuild = standardturret;
    }

    private GameObject turrettobuild;

    public GameObject Getturrettobuild()
    {
        Bal = false;
        return turrettobuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turrettobuild = turret;
    }
}