using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class PostVisual : MonoBehaviour
{
    public float postWeight = 1;
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
        postProcessVolume.weight = postWeight;
    }
}
