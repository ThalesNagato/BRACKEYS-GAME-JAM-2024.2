using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLoop : MonoBehaviour
{
    public Vector2 startPosition;
    public Vector2 endPosition;
    public float moveSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + moveSpeed *Time.deltaTime, transform.position.y);
       
        if(transform.position.x < endPosition.x)
        {
            transform.position = new Vector2(startPosition.x, transform.position.y);
        }
    }
}
