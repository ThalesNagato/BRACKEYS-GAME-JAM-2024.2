using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostVisual : MonoBehaviour
{
    public int _band;
    public PostProcessVolume _PPV;

    void Start()
    {
        
    }

    void Update()
    {
        if (AudioVisualizer._audioBandBuffer[_band] > 0.5f)
        {
          _PPV.enabled = true;
          
        }
        else
        {
            _PPV.enabled = false;

        }
    }
}
