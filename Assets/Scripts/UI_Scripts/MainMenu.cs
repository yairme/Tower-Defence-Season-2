using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject A;
    [SerializeField] private GameObject B;

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
