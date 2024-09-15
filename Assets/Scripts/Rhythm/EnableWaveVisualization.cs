using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnableWaveVisualization : MonoBehaviour
{
    public FrequencyVisuals frequencyVisuals;
    public EnableWaveVisualization enableWaveVisualization;

    public float Timer = 1;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        frequencyVisuals = GetComponent<FrequencyVisuals>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Conductor.songPositionInBeats >= 6)
        {
            timer += Time.deltaTime;
        }

        if(timer > Timer)
        {
            frequencyVisuals.enabled = true;
            enableWaveVisualization.enabled = true;
        }
    }
}
