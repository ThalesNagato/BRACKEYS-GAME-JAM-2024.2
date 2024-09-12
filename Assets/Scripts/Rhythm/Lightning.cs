using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public float lightningFadeTime;

    private SpriteRenderer _renderer;


    public void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, 0);
    }

    public void Update()
    {
        _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, _renderer.color.a - lightningFadeTime * Time.deltaTime);
    }


    public void LightningStrike()
    {

        _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, 1);
    }
}
