using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigtningTest : MonoBehaviour
{
    public int _band;
    public SpriteRenderer _renderer;
    public float start;
    public float end;
    float opacity = 1;
    
    void Start()
    {
        
    }


    void Update()
    {

       if (AudioVisualizer._audioBandBuffer[_band] > 0.5f)
        {
            opacity = 1;
            _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, opacity);
            //transform.position = new Vector2(Random.Range(start, end), transform.position.y);
        }
        else
        {

            _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, 0);
        }

        //Debug.Log(AudioVisualizer._audioBandBuffer[_band]);
    }
}
