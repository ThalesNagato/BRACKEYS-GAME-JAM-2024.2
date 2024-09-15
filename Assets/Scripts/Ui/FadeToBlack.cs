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
                interpolate = 0;
                isFading = false;
                timer += Time.deltaTime;
            }

            if (timer >= blackTime)
            {
                SceneManager.LoadScene("FINAL SCENE");
                GetComponent<Canvas>().sortingOrder = -1;
            }


            
        }
    }

    public void Fade()
    {
        isFading = true;
    }
}
