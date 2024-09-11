using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateSignafier(bool rotate)
    {
        if (rotate)
        {
            transform.Rotate(0, 0, 20);
        } else
        {
            transform.Rotate(0, 0, 0);
        }
    
    }
}
