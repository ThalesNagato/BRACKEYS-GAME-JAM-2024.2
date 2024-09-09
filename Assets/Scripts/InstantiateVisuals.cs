using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InstantiateVisuals : MonoBehaviour
{
    public GameObject _visualPrefab;
    public float _maxScale;
    GameObject[] _visuals = new GameObject[512];

    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject _instanceVisual = (GameObject)Instantiate(_visualPrefab);
            _instanceVisual.transform.position = this.transform.position;
            _instanceVisual.transform.parent = this.transform;
            _instanceVisual.name = "Visual" + i;
            _instanceVisual.transform.position = Vector2.right * (1f * i);
            _visuals[i] = _instanceVisual;
        }
    }

    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if (_visuals != null)
            {
                _visuals[i].transform.localScale = new Vector2(1, (AudioVisualizer._samples[i] * _maxScale)+0.1f);
                _visuals[i].GetComponentInChildren<SpriteRenderer>().color = Random.ColorHSV(0.60f, 0.80f, 1f, 1f, 0.5f, 1f);
            }
        }
    }
}
