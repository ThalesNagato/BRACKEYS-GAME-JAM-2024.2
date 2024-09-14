using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWaveVisualization : MonoBehaviour
{
    public FrequencyVisuals frequencyVisuals;
    public EnableWaveVisualization enableWaveVisualization;

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
            frequencyVisuals.enabled = true;
            Destroy(enableWaveVisualization);
        }
    }
}
