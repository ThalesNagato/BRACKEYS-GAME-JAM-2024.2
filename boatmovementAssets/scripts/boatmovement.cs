using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatmovement : MonoBehaviour
{

    private float time;

    private float speed;
    private float height;
    
    public float bpm;
    private float bps;

    // Start is called before the first frame update
    void Start()
    {
        height = 2f;       
    }

    // Update is called once per frame
    void Update()
    {
        bps = bpm/60;  
        speed = bps * Mathf.PI;
        time += Time.deltaTime;  
        transform.position= new Vector2(0, (height * Mathf.Cos(time * speed)));
    }
}
