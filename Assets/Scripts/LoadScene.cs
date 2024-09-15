using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
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
