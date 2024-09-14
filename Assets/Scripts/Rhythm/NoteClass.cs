using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class NoteClass : MonoBehaviour
{
    public float beatPlay;
    public Vector2 startPos;
    public Vector2 endPos;
    public string keyName;
    public Color noteColor;
    public bool lightningStrike;
    public bool woodKnock;
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


    public void Start()
    {
        noteSpawner = GameObject.Find("Note Spawner");
        noteScript = noteSpawner.GetComponent<NoteSpawner>();

        boat = GameObject.Find("Boat");
        boatScript = boat.GetComponent<BoatMovement>();
        boatScript.GetCurrentNote(gameObject);

        lightning = GameObject.Find("Lightning");
        lightningScript = lightning.GetComponent<Lightning>();

        post = GameObject.Find("Main Camera");
        postScript = post.GetComponent<PostVisual>();

        GetComponent<SpriteRenderer>().material.color = noteColor;

        if (keyName == "right")
        {
            transform.Rotate(0, 0, 180);
        }

        if (keyName == "a")
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void Update()
    {
        MoveNote();
        
        InputCheck();

        LightningCheck();

        DestroyOnBeatEnd();

        

        
        
    }

    public void MoveNote()
    {
        interpolate = (noteScript.beatsShownInAdvance - (beatPlay - Conductor.songPositionInBeats)) / noteScript.beatsShownInAdvance;
        transform.position = Vector2.Lerp(
            startPos,
            endPos,
            interpolate
            );
    }

    public void InputCheck()
    {
        if (keyName == "left" || keyName == "right")
        {
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

                    if (hit2D.collider.tag == "BeatMarker")
                    {
                        
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
                }
                if (Conductor.songPositionInBeats > beatPlay + safety - beatDelay)
                {
                    GetComponent<SpriteRenderer>().material.color = missColor;
                }
            }
        }
    }

    public void LightningCheck()
    {
        if (Conductor.songPositionInBeats > beatPlay - safety/4 - beatDelay && Conductor.songPositionInBeats < beatPlay + safety/4 - beatDelay)
        {
            if (lightningStrike)
            {
                lightningScript.LightningStrike();
                postScript.Flash();
            }
        }
    }

    public void KnockCheck()
    {
        if (Conductor.songPositionInBeats > beatPlay - safety - beatDelay && Conductor.songPositionInBeats < beatPlay + safety - beatDelay)
        {
            if (woodKnock)
            {

            }
        }
    }

    public void DestroyOnBeatEnd()
    {
        if (interpolate >= 0.9)
        {
            Destroy(gameObject);
        }
    }
}


