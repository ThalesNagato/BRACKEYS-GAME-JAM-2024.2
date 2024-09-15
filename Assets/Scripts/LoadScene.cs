using System.Collections;
using System.Collections.Generic;
<<<<<<< Updated upstream
using System.Threading;
using Unity.VisualScripting;
=======
>>>>>>> Stashed changes
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
<<<<<<< Updated upstream
    public float restartTime = 1;

    private float timer = 0;

    void Start()
    {
        
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= restartTime)
        {
            GameObject[] beats = GameObject.FindGameObjectsWithTag("Beat");
            foreach (GameObject beat in beats)
            {
                Conductor.songPositionInBeats = 0;
                Destroy(beat);
            }

            SceneManager.LoadScene("FINAL SCENE");
            
        }

    }


}
=======
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
>>>>>>> Stashed changes
