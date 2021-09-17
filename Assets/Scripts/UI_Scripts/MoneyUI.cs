using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;
    public Text liveText;
    public Text Wave;

    private PlayerStats MN;
    private WaveSpawner WV;

    public void Start()
    {
        MN = GameObject.FindWithTag("GM").GetComponent<PlayerStats>();
        WV = GameObject.FindWithTag("GM").GetComponent<WaveSpawner>();
    }

    public void Update()
    {
        if (MN != null || MN != null)
        {
            moneyText.text = "$" + MN.Money.ToString();
            liveText.text = "Lives: " + MN.Lives.ToString();
            Wave.text = "Wave: " + WV.waveNumber.ToString();
        }
        else
        {
            MN = GameObject.FindWithTag("GM").GetComponent<PlayerStats>();
        }

    }
}