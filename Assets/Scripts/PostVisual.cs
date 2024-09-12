using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostVisual : MonoBehaviour
{

    public float postFadeTime;
    public PostProcessVolume postProcessVolume;
    void Start()
    {
        postProcessVolume.weight = 0;
    }

    void Update()
    {
        postProcessVolume.weight -= postFadeTime * Time.deltaTime;
    }

    public void Flash()
    {
        postProcessVolume.weight = 1;
    }
}
