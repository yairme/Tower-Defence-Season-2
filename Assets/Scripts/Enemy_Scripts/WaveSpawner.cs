using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    private GameManager GM;
    private levelchange LC;

    public int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 10f;
    private float countdown = 6f;

    public Text waveCountDownText;
    
    [HideInInspector]public int waveNumber = 0;

    public void Start()
    {
        GM = GameObject.FindWithTag("GM").GetComponent<GameManager>();
        LC = GameObject.FindWithTag("GM").GetComponent<levelchange>();
    }

    public void Update()
    {
        if (EnemiesAlive <= -1)
        {
            EnemiesAlive = 0;
        }

        if (EnemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            if (GM.gameEnded)
                return;
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveNumber];
            
        for (int i = 0; i < wave.count; i++)
        {
            Looping();
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveNumber++;
    }

    void Looping()
    {
        Wave wave = waves[waveNumber];

        for (int j = 0; j < wave.enemy.Length; j++)
        {
            SpawnEnemy(wave.enemy[j]);
        }

        if (waveNumber >= waves.Length - 1 && EnemiesAlive <= 0)
        {
            LC.Win();
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
