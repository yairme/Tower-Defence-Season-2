using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExitShop : MonoBehaviour
{
    public Canvas shopUI;
    public GameObject build;
    private buildmanager bu;
    private void Start()
    {
        bu = build.GetComponent<buildmanager>();
    }


    public void Exit()
    {
        shopUI.gameObject.SetActive(false);
        bu.i = false;
    }
}
