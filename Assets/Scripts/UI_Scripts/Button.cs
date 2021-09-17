using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [HideInInspector] public Inventory inv;
    [HideInInspector] public bool hasbought;
    [HideInInspector] public bool follow;
    
    public GameObject turret;
    public GameObject shopmanager;
    public void Start()
    {
        inv = shopmanager.GetComponent<Inventory>();
    }


    public void buy()
    {
        Debug.Log("bought");
        if (inv.Points > 0)
        {
            inv.Points -= 5;
        }
       
        else
        {
            Debug.Log("no points");
        }

    }
}
