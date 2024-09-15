using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNames : MonoBehaviour
{
    public float nightSpeed;
    public GameObject background;
    private SpriteRenderer backgroundSprite;
    private float interpolate;
    
   
    // Start is called before the first frame update
    void Start()
    {
        background = GameObject.Find("Background");
        backgroundSprite = background.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Conductor.songPositionInBeats >= 140)
        {

            interpolate += nightSpeed * Time.deltaTime;
            backgroundSprite.color = Color.Lerp(backgroundSprite.color, new Color(0.1132075f, 0.0537256f, 0f), interpolate);


            GetComponent<Animator>().SetBool("End", true);
        }
    }
}
