using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pauseanim : MonoBehaviour
{
    private Pause GM;
    public GameObject pausetext;
    Animator pausing;

    private void Start()
    {
        GM = GameObject.FindWithTag("GM").GetComponent<Pause>();
        pausing = pausetext.GetComponent<Animator>();

    }
    private void Update()
    {
        if (GM.gameIsPaused)
        {
            pausetext.SetActive(true);
        }
    }
    
    private IEnumerator waitforsec()
    {
        pausing.Play("pausing");
        yield return new WaitForSeconds(0.167f);
        
    }
}
