using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public float interpolate = 1;
    public float fadeSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        interpolate -= fadeSpeed * Time.deltaTime;
        GetComponent<CanvasGroup>().alpha = interpolate;

        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("FINAL SCENE");
        }
    }
}

