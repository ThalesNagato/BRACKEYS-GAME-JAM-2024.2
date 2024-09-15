using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatmovement : MonoBehaviour
{
    public float lives;

    public float height = 2f;

    private float time;

    private float speed;
    
    public float bpm;
    private float bps;

    private bool gameStarted;

    public GameObject noteSpawner;


    // Start is called before the first frame update
    void Start()
    {    
        bpm = 0;
        time = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(noteSpawner.activeSelf == true){
            //time = 0;
            bpm = 75;
            gameStarted = true;
        }
         

        if (gameStarted) {
            bps = bpm / 60;
            time += Time.deltaTime;
            speed = bps * Mathf.PI;
            transform.position = new Vector2(transform.position.x, transform.position.y + (height * 5f * Mathf.Cos(time * speed)));
        }

       

    }
}
