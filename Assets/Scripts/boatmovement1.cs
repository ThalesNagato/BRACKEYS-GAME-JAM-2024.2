using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatmovement : MonoBehaviour
{
    public float height = 2f;

    private float time;

    private float speed;
    
    public float bpm;
    private float bps;

    

    // Start is called before the first frame update
    void Start()
    {    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bps = bpm/60;  
        speed = bps * Mathf.PI;
        time += Time.deltaTime;  
        transform.position= new Vector2(transform.position.x, transform.position.y + (height*5 * Mathf.Cos(time * speed)));
    }
}
