using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMenu : MonoBehaviour
{
    private pause GM;
    public GameObject A;
    public GameObject B;

    private void Start()
    {
        GM = GameObject.FindWithTag("GM").GetComponent<pause>();
    }

    public void Quit()
    {
        
        Time.timeScale = 1f;
        SceneManager.LoadScene("mainmenu");
    }

    public void ReLoad()
    {
        
        GM.PausedMenu = !GM.PausedMenu;
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
        GM.alreadypausedB = !GM.alreadypausedB;
    }
    public void Resume()
    {
        GM.PausedMenu = !GM.PausedMenu;
        B.SetActive(false);
        Time.timeScale = 1;
        GM.alreadypausedB = !GM.alreadypausedB;
    }
}
