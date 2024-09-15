using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public float fadeInBeat;
    public float fadeOutBeat;
    public float fadeSpeed;

    private CanvasGroup canvasGroup;
    private float interpolatePlus = 0;
    private float interpolateMinus = 1;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Conductor.songPositionInBeats > fadeInBeat && Conductor.songPositionInBeats < fadeOutBeat)
        {
            interpolatePlus += fadeSpeed * Time.deltaTime;

            canvasGroup.alpha = interpolatePlus;

        }

        if (Conductor.songPositionInBeats > fadeOutBeat)
        {
            interpolateMinus -= fadeSpeed * Time.deltaTime;

            canvasGroup.alpha = interpolateMinus;

        }
    }
}
