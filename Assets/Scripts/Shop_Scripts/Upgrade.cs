using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : shop
{
    private bool _Level_2;
    private bool _Level_3;

    public void Placestandard_2()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        if (ST.Money >= 249)
        {
            BM.Bal = true;
            BM.SetTurretToBuild(BM.standardturret_2);
            ST.Money -= 250;
            returnMoney = 250;
            Destroy(this.gameObject);
        }
        else if (ST.Money < 249)
        {
            NotenoughMoney();
        }
    }

    public void Placelaser_2()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        if (ST.Money >= 299)
        {
            BM.Bal = true;
            BM.SetTurretToBuild(BM.laserturret_2);
            ST.Money -= 300;
            returnMoney = 300;
            Destroy(this.gameObject);
        }
        else if (ST.Money <= 299)
        {
            NotenoughMoney();
        }
    }

    public void Placemissile_2()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        if (ST.Money >= 399)
        {
            BM.Bal = true;
            BM.SetTurretToBuild(BM.Missileturret_2);
            ST.Money -= 400;
            returnMoney = 400;
            Destroy(this.gameObject);
        }
        else if (ST.Money <= 399)
        {
            NotenoughMoney();
        }
    }

    public void PlaceLightning_2()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        if (ST.Money >= 375)
        {
            BM.Bal = true;
            BM.SetTurretToBuild(BM.Lightningturret_2);
            ST.Money -= 375;
            returnMoney = 375;
            Destroy(this.gameObject);
        }
        else if (ST.Money <= 374)
        {
            NotenoughMoney();
        }
    }

    public void Placestandard_3()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        if (ST.Money >= 349)
        {
            BM.Bal = true;
            BM.SetTurretToBuild(BM.standardturret_3);
            ST.Money -= 350;
            returnMoney = 350;
            Destroy(this.gameObject);
        }
        else if (ST.Money < 349)
        {
            NotenoughMoney();
        }
    }

    public void Placelaser_3()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        if (ST.Money >= 399)
        {
            BM.Bal = true;
            BM.SetTurretToBuild(BM.laserturret_3);
            ST.Money -= 400;
            returnMoney = 400;
            Destroy(this.gameObject);
        }
        else if (ST.Money <= 399)
        {
            NotenoughMoney();
        }
    }

    public void Placemissile_3()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        if (ST.Money >= 499)
        {
            BM.Bal = true;
            BM.SetTurretToBuild(BM.Missileturret_3);
            ST.Money -= 500;
            returnMoney = 500;
            Destroy(this.gameObject);
        }
        else if (ST.Money <= 499)
        {
            NotenoughMoney();
        }
    }

    public void PlaceLightning_3()
    {
        if (PS == null)
        {
            PS = GameObject.FindGameObjectWithTag("Grid").GetComponent<Placement>();
        }

        if (ST.Money >= 475)
        {
            BM.Bal = true;
            BM.SetTurretToBuild(BM.Lightningturret_3);
            ST.Money -= 475;
            returnMoney = 475;
            Destroy(this.gameObject);
        }
        else if (ST.Money <= 474)
        {
            NotenoughMoney();
        }
    }

    public void Sell()
    {
        BM.upGrade.SetActive(false);
        ST.Money +=returnMoney;
        returnMoney = returnMoneyB;
        Destroy(this.gameObject);
    }
}
