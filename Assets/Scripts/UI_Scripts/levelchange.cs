using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelchange : MonoBehaviour
{
    public void Lose()
    {
        SceneManager.LoadScene("LoseScreen");
    }
    public void Win()
    {
        SceneManager.LoadScene("WinScreen");
    }
}
