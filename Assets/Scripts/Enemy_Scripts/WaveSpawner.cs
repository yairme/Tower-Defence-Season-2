using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    private GameManager GM;
    private Levelchange LC;

    public int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 10f;
    private float countdown = 6f;
    private int _flashes = 3;

    [HideInInspector] public bool started = false;

    [Header("Visual")]
    public GameObject warning;

    private bool isNextWave = true;

    [HideInInspector] public int waveNumber = 0;

    public void Start()
    {
        GM = GameObject.FindWithTag("GM").GetComponent<GameManager>();
        LC = GameObject.FindWithTag("GM").GetComponent<Levelchange>();
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

        if (started)
        {
            if (countdown <= 0f)
            {
                if (GM.gameEnded)
                    return;
                if (!isNextWave)
                {
                    Warning();
                    isNextWave = true;
                }
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
                return;
            }
            else
            {
                if (isNextWave)
                {
                    Warning();
                    isNextWave = false;
                }
            }
        }
        if (started)
        {
            countdown -= Time.deltaTime;

            countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        }
    }

    private IEnumerator SpawnWave()
    {
        Wave wave = waves[waveNumber];

        for (int i = 0; i < wave.count / wave.enemy.Length; i++)
        {
            for (int j = 0; j < wave.enemy.Length; j++)
            {
                SpawnEnemy(wave.enemy[j]);
                yield return new WaitForSeconds(1f / wave.rate);
            }
        }
        if (waveNumber >= waves.Length - 1 && EnemiesAlive <= 0)
        {
            LC.Win();
            this.enabled = false;
        }
        waveNumber++;
    }

    public void Warning()
    {
        if (isNextWave == false)
        {
            warning.SetActive(false);
        }
        else
        {
            StartCoroutine(WaveWarning());
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }

    private IEnumerator WaveWarning()
    {
        for (int i = 0; i < _flashes; i++)
        {
            warning.SetActive(true);
            yield return new WaitForSeconds(2f);
            warning.SetActive(false);
            yield return new WaitForSeconds(1f);
        }
    }
}