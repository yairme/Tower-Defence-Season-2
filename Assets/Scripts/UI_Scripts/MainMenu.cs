using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject A;
    [SerializeField] private GameObject B;
    [SerializeField] private GameObject C;
    [SerializeField] private GameObject D;

    public void NewGame()
    {
        A.gameObject.SetActive(true);
        B.gameObject.SetActive(false);
        C.gameObject.SetActive(true);
        D.gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
    public void MM()
    {
        SceneManager.LoadScene("mainmenu");
    }
    public void Load()
    {
        A.gameObject.SetActive(true);
        B.gameObject.SetActive(false);
    }

}
