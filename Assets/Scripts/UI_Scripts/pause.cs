using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool gameIsPaused;
    public bool pausedMenu;

    public GameObject pausetext;
    public GameObject pausemenu;

    private bool _alreadypausedA;
    [HideInInspector] public bool alreadypausedB = false;

    public GameObject toStart;
    private WaveSpawner WP;

    public void Start()
    {
        WP = GameObject.FindWithTag("GM").GetComponent<WaveSpawner>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!alreadypausedB)
        {
            if (alreadypausedB)
                return;
            gameIsPaused = !gameIsPaused;
            PauseGame();
            _alreadypausedA = !_alreadypausedA;
        }
        if (Input.GetKeyDown(KeyCode.Escape)&&!_alreadypausedA)
        {
            if (_alreadypausedA)
                return;
            pausedMenu = !pausedMenu;
            PausingMenu();
            alreadypausedB = !alreadypausedB;
        }
    }

    private void PauseGame()
    {
        if (gameIsPaused)
        {
            pausetext.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausetext.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private void PausingMenu()
    {
        if (pausedMenu)
        {
            pausemenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausemenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void StartGame()
    {
        WP.started = true;
        toStart.SetActive(false);
    }
}