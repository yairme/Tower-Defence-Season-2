using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    private buildmanager BM;
    private shop PS;
    private PlayerStats ST;

    public Color hovercolor;
    [HideInInspector]public Color startcolor;
    [HideInInspector]public SpriteRenderer rend;
    private GameObject turret;
    public bool activeshop;


    public void Start()
    {
        BM = GameObject.FindWithTag("GM").GetComponent<buildmanager>();
        PS = GameObject.FindWithTag("Shop").GetComponent<shop>();
        ST = GameObject.FindWithTag("GM").GetComponent<PlayerStats>();

        rend = GetComponent<SpriteRenderer>();
        startcolor = rend.material.color;
    }


    public void OnMouseDown()
    {
        if (BM.Bal == false)
            return;
        if(BM.instance.Getturrettobuild() == null)
        {
            return;
        }
        if(turret != null)
        {
            Debug.Log("already build here TODO: display on screen");
            ST.Money += PS.returnMoney;
            PS.returnMoney = PS.returnMoneyB;
            return;
        }
        GameObject TurretToBuild = BM.instance.Getturrettobuild();
        turret = (GameObject)Instantiate(TurretToBuild, transform.position, transform.rotation);

    }
    public void OnMouseEnter()
    {
        rend.material.color = hovercolor;
    }
    public void OnMouseExit()
    {
        rend.material.color = startcolor;
    }
}
