using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool gameIsPaused;
    public bool PausedMenu;

    public GameObject pausetext;
    public GameObject pausemenu;

    protected bool alreadypausedA = false;
    [HideInInspector] public bool alreadypausedB = false;

    public GameObject toStart;
    private WaveSpawner WP;

    public void Start()
    {
        WP = GameObject.FindWithTag("GM").GetComponent<WaveSpawner>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!alreadypausedB)
        {
            if (alreadypausedB == true)
                return;
            gameIsPaused = !gameIsPaused;
            PauseGame();
            alreadypausedA = !alreadypausedA;
        }
        if (Input.GetKeyDown(KeyCode.Escape)&&!alreadypausedA)
        {
            if (alreadypausedA == true)
                return;
            PausedMenu = !PausedMenu;
            PausingMenu();
            alreadypausedB = !alreadypausedB;
        }
    }
    public void PauseGame()
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

    public void PausingMenu()
    {
        if (PausedMenu)
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