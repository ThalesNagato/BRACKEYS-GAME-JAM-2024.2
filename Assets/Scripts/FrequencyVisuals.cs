using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrequencyVisuals : MonoBehaviour
{
    public int _band;
    public float _startScale, _maxScale;
    public bool _useBuffer;
    SpriteRenderer _spriteRenderer;
    void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (_useBuffer)
        {
            transform.localScale = new Vector2(transform.localScale.x, (AudioVisualizer._audioBandBuffer[_band] * _maxScale) + _startScale);
            Color _color = new Color(AudioVisualizer._audioBandBuffer[_band], AudioVisualizer._audioBandBuffer[_band], 1);
            _spriteRenderer.color = _color;
        }

        if (!_useBuffer)
        {
            transform.localScale = new Vector2(transform.localScale.x, (AudioVisualizer._audioBand[_band] * _maxScale) + _startScale);
            Color _color = new Color(AudioVisualizer._audioBand[_band], AudioVisualizer._audioBand[_band], AudioVisualizer._audioBand[_band]);
           // _spriteRenderer.color = _color;

        }
        

    }
}
