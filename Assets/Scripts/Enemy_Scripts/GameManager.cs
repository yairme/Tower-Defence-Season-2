using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameEnded = false;

    private PlayerStats ST;
    private levelchange LC;

    public void Start()
    {
        ST = GameObject.FindWithTag("GM").GetComponent<PlayerStats>();
        LC = GameObject.FindWithTag("GM").GetComponent<levelchange>();
    }
    public void Update()
    {
        if (gameEnded)
            return;
        if (ST != null)
        {
            if (ST.Lives <= 0)
            {
                EndGame();
            }
        }
        else
        {
            ST = GameObject.FindWithTag("GM").GetComponent<PlayerStats>();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        LC.Lose();
    }
}
