using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    private PlayerStats ST;
    private buildmanager BM;
    private Placement PS;

    [HideInInspector] public GameObject turret;

    [HideInInspector] public int returnMoneyB = 0;
    [HideInInspector] public int returnMoney;

    public void Start()
    {
        PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        BM = GameObject.FindWithTag("GM").GetComponent<buildmanager>();
        ST = GameObject.FindWithTag("GM").GetComponent<PlayerStats>();
        returnMoney = returnMoneyB;
    }
    public void Placestandard()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        if (ST.Money > 149)
        {
            BM.Bal = true;
            BM.SetTurretToBuild(BM.standardturret);
            ST.Money -= 150;
            returnMoney = 150;
        }
        else if (ST.Money < 149)
        {
            RenderColor();
        }
    }

    public void Placelaser()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        if (ST.Money > 199)
        {
            BM.Bal = true;
            BM.SetTurretToBuild(BM.laserturret);
            ST.Money -= 200;
            returnMoney = 200;
        }
        else if (ST.Money <= 199)
        {
            RenderColor();
        }
    }

    public void Placemissile()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        if (ST.Money > 299)
        {
            BM.Bal = true;
            BM.SetTurretToBuild(BM.Missileturret);
            ST.Money -= 300;
            returnMoney = 300;
        }
        else if (ST.Money <= 299)
        {
            RenderColor();
        }
    }

    void RenderColor()
    {
        PS.rend.material.color = Color.red;
        PS.rend.material.color = PS.startcolor;
    }
}