using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_AI : MonoBehaviour
{
    private WaveSpawner WS;
    private PlayerStats ST;


    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float health;
    private float startHealth = 100f;

    public int value;

    [Header("Unity stuff")]
    public Image healthBar;


    private void Start()
    {
        WS = GameObject.FindWithTag("GM").GetComponent<WaveSpawner>();
        ST = GameObject.FindWithTag("GM").GetComponent<PlayerStats>();

        speed = startSpeed;
        startHealth = health;
    }

    public void TakeDamage (float amount)
    {
        startHealth -= amount;

        healthBar.fillAmount = startHealth / health;
        
        if (startHealth <= 0)
        {
            Die();
        }
    }

    public void Slow (float pct)
    {
        speed = speed * (1f - pct);
    }

    void Die()
    {
        ST.Money += value;
        WS.EnemiesAlive--;
        Destroy(gameObject);
    }
}

