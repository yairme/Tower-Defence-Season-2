using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildmanager : MonoBehaviour
{
    [HideInInspector] public buildmanager instance;
    public bool i;

    public bool Bal = false;
    protected PlayerStats ST;
    protected buildmanager BM;
    protected shop SH;
    public GameObject upGrade;

    [Header("Level_1")]
    public GameObject standardturret;
    public GameObject laserturret;
    public GameObject Missileturret;
    public GameObject Lightningturret;

    [Header("Level_2")]
    public GameObject standardturret_2;
    public GameObject laserturret_2;
    public GameObject Missileturret_2;
    public GameObject Lightningturret_2;

    [Header("Level_3")]
    public GameObject standardturret_3;
    public GameObject laserturret_3;
    public GameObject Missileturret_3;
    public GameObject Lightningturret_3;

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one buildmanager");
            return;
        }
        instance = this;
    }


    public void Start()
    {
        BM = GameObject.FindWithTag("GM").GetComponent<buildmanager>();
        ST = GameObject.FindWithTag("GM").GetComponent<PlayerStats>();
        SH = GameObject.FindWithTag("GM").GetComponent<shop>();
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