using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineVisualization : MonoBehaviour
{
    LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();

        line.positionCount = 512;

        for (int i = 0; i < 8; i++)
        {
           // line.SetPosition(i, transform.position + line.GetPosition(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            line.SetPosition(i, new Vector3 (transform.position.x +(i * 1f), AudioVisualizer._samples[i] *100, transform.position.z));
            
            //line.SetPosition(i, new Vector3(line.GetPosition(i).x, AudioVisualizer._audioBandBuffer[i] * 10, line.GetPosition(i).z));
            //line.colorGradient

        }
    }
}
