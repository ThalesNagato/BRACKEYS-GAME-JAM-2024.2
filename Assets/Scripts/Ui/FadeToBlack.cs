using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class FadeToBlack : MonoBehaviour
{
    public float fadeSpeed;
    public float blackTime;

    private bool isFading;
    private float interpolate = 0;
    private bool timerOn = false;
    private float timer = 0;

    void Start()
    {
        
    }

  
    void Update()
    {
        if (isFading)
        {
            GetComponent<Canvas>().sortingOrder = 10;
            interpolate += fadeSpeed * Time.deltaTime;
            GetComponent<CanvasGroup>().alpha = interpolate;

            if(interpolate >= 1)
            {
                timerOn = true;
            }

            if (timerOn)
            {
                timer += Time.deltaTime;
            }

            if (timer >= blackTime)
            {

                Conductor.songPositionInBeats = 0;
                Conductor.dspSongTime = 0;
                SceneManager.LoadScene("Failure");


              
            }


            
        }

        if (Input.GetKeyDown("r"))
        {
            isFading = true;
        }
    }

    public void Fade()
    {
        isFading = true;
    }
}
