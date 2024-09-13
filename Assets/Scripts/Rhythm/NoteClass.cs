using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class NoteClass : MonoBehaviour
{
    public float beatPlay;
    public Vector2 startPos;
    public Vector2 endPos;
    public string keyName;
    public Color noteColor;
    public bool lightningStrike;
    public GameObject barPrefab;
    public Color hitColor;
    public Color missColor;

    public float safety = 0.5f;
    public float beatDelay = 2;
    public float endZone;

    public float interpolate;
    public GameObject noteSpawner;
    public GameObject boat;
    public GameObject barMarker;
    public GameObject lightning;
    public GameObject post;
    public GameObject scrollBar;

    private NoteSpawner noteScript;
    private BoatMovement boatScript;
    private ScrollBar barScript;
    private Lightning lightningScript;
    private PostVisual postScript;
    private bool keyPressed;
    private RaycastHit2D hit2D;

    //private bool noteHit = false;



    public void Start()
    {
        noteSpawner = GameObject.Find("Note Spawner");
        noteScript = noteSpawner.GetComponent<NoteSpawner>();

        boat = GameObject.Find("Boat");
        boatScript = boat.GetComponent<BoatMovement>();
        boatScript.GetCurrentNote(gameObject);

        //scrollBar = GameObject.Find("ScrollBar");
        //Instantiate(barPrefab, scrollBar.transform);

        //barMarker= GameObject.Find("BarMarker(Clone)");
        //barScript = barMarker.GetComponent <ScrollBar>();
        //barScript.GetCurrentNote(gameObject);


        lightning = GameObject.Find("Lightning");
        lightningScript = lightning.GetComponent<Lightning>();

        post = GameObject.Find("Main Camera");
        postScript = post.GetComponent<PostVisual>();

        GetComponent<SpriteRenderer>().material.color = noteColor;

        if(keyName == "right")
        {
            transform.Rotate(0, 0, 180);
        }


    }


    public void Update()
    {

        interpolate = (noteScript.beatsShownInAdvance - (beatPlay - Conductor.songPositionInBeats)) / noteScript.beatsShownInAdvance;

        transform.position = Vector2.Lerp(
            startPos,
            endPos,
            interpolate
            );

        if (interpolate >= 0.9)
        {
            Destroy(gameObject);
        }



        if (Conductor.songPositionInBeats > beatPlay - safety - beatDelay && Conductor.songPositionInBeats < beatPlay + safety - beatDelay)
        {

            if (lightningStrike)
            {
                lightningScript.LightningStrike();
                postScript.Flash();
            }
        }

        if (!keyPressed)
        {
            if (Input.GetKeyDown(keyName))
            {

                if (keyName == "left")
                {
                    hit2D = Physics2D.Raycast(transform.position, Vector2.left);

                }
                if (keyName == "right")
                {
                    hit2D = Physics2D.Raycast(transform.position, Vector2.right);
                }

                UnityEngine.Debug.Log(hit2D.collider.tag);

                if (hit2D.collider.tag == "BeatMarker")
                {
                    //UnityEngine.Debug.Log(hit2D.collider.tag);
                    if (Conductor.songPositionInBeats > beatPlay - safety - beatDelay && Conductor.songPositionInBeats < beatPlay + safety - beatDelay)
                    {
                        keyPressed = true;
                        GetComponent<SpriteRenderer>().material.color = hitColor;
                    }
                    else
                    {
                        keyPressed = true;
                        GetComponent<SpriteRenderer>().material.color = missColor;
                    }
                }
                //else
                //{
                //    UnityEngine.Debug.Log(hit2D);
                //    UnityEngine.Debug.Break();
                //    keyPressed = true;
                //    GetComponent<SpriteRenderer>().material.color = missColor;
                //}
            }
            if (Conductor.songPositionInBeats > beatPlay + safety - beatDelay)
            {
                GetComponent<SpriteRenderer>().material.color = missColor;
            }
            //else if (Input.anyKeyDown)
            //{
            //    GetComponent<SpriteRenderer>().material.color = missColor;
            //    keyPressed = true;
            //}
        }
    }
}


