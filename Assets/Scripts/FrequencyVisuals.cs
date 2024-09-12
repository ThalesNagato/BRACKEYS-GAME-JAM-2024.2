using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrequencyVisuals : MonoBehaviour
{
    public int _band;
    public float _startScale, _maxScale;
    public bool _useBuffer;
    SpriteRenderer _spriteRenderer;
    public float colorBuffer = 0.5f;
    private Color startColor;
    void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        startColor = _spriteRenderer.color;

    }

    void Update()
    {
        if (_useBuffer)
        {
            transform.localScale = new Vector2(transform.localScale.x, (AudioVisualizer._audioBandBuffer[_band] * _maxScale) + _startScale);
            Color _color = new Color(startColor.r + AudioVisualizer._audioBandBuffer[_band] * colorBuffer, startColor.g + AudioVisualizer._audioBandBuffer[_band] * colorBuffer, startColor.b + AudioVisualizer._audioBandBuffer[_band] * colorBuffer);
            _spriteRenderer.color = _color;
        }

        if (!_useBuffer)
        {
            transform.localScale = new Vector2(transform.localScale.x, (AudioVisualizer._audioBand[_band] * _maxScale) + _startScale);
            Color _color = new Color(startColor.r + AudioVisualizer._audioBand[_band] * colorBuffer, startColor.g + AudioVisualizer._audioBand[_band] *colorBuffer, startColor.b + AudioVisualizer._audioBand[_band] *colorBuffer);
            //Debug.Log(_spriteRenderer.color.r + " / " + AudioVisualizer._audioBandBuffer[_band]);
            _spriteRenderer.color = _color;

        }
        

    }
}
