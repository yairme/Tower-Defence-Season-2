using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    protected PlayerStats ST;
    protected buildmanager BM;
    protected Placement PS;

    [Header("If there's not enough money.")]
    public GameObject noMoney;

    [HideInInspector] public GameObject turret;

    [HideInInspector] public int returnMoneyB = 0;
    [HideInInspector] public int returnMoney;

    protected float timer = 1;

    public void Start()
    {
        PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        BM = GameObject.FindWithTag("GM").GetComponent<buildmanager>();
        ST = GameObject.FindWithTag("GM").GetComponent<PlayerStats>();
        returnMoney = returnMoneyB;
    }

    public void Update()
    {
        if(timer > 0)
            timer -= Time.deltaTime;
        else
            noMoney.SetActive(false);
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
            NotenoughMoney();
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
            NotenoughMoney();
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
            NotenoughMoney();
        }
    }

    public void PlaceLightning()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        if (ST.Money > 274)
        {
            BM.Bal = true;
            BM.SetTurretToBuild(BM.Lightningturret);
            ST.Money -= 275;
            returnMoney = 275;
        }
        else if (ST.Money <= 274)
        {
            NotenoughMoney();
        }
    }

    public void NotenoughMoney()
    {
        timer = 3;
        noMoney.SetActive(true);
    }
}