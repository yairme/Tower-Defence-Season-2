using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningSprites : MonoBehaviour
{
    private Enemy_Movement EN;

    public Sprite spriteLeft, spriteRight, spriteUp, spriteDown;

    public void Start()
    {
        EN = this.gameObject.GetComponent<Enemy_Movement>();
    }
    public void Update()
    {
        EN = this.gameObject.GetComponent<Enemy_Movement>();
        if (EN != null)
        {
            if (EN.eulerAngZ >= 70 && EN.eulerAngZ <= 110)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteUp;
            }

            if (EN.eulerAngZ >= 340 || EN.eulerAngZ <= 10)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteRight;
            }

            if (EN.eulerAngZ >= 260 && EN.eulerAngZ <= 280)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteDown;
            }

            if (EN.eulerAngZ >= 170 && EN.eulerAngZ <= 190)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteLeft;
            }
        }
        else
        {
            EN = this.gameObject.GetComponent<Enemy_Movement>();
        }
    }
}
