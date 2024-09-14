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
    public bool drumStick;
    public GameObject barPrefab;
    public Color hitColor;
    public Color missColor;

    public float safety = 0.5f;
    public float beatDelay = 2;
    public float endZone;
    public float interpolate;

    private GameObject noteSpawner;
    private GameObject boat;
    private GameObject barMarker;
    private GameObject lightning;
    private GameObject post;
    private GameObject scrollBar;
    private NoteSpawner noteScript;
    private BoatMovement boatScript;
    private Lightning lightningScript;
    private PostVisual postScript;
    private UnityEngine.UI.Image barColor;
    private Color BarStartColor;
    private bool keyPressed;
    private RaycastHit2D hit2D;
    private bool isRed = false;
    private bool isYellow = false;



    public void Start()
    {
        noteSpawner = GameObject.Find("Note Spawner");
        noteScript = noteSpawner.GetComponent<NoteSpawner>();

        boat = GameObject.Find("Boat");

        lightning = GameObject.Find("Lightning");
        lightningScript = lightning.GetComponent<Lightning>();

        post = GameObject.Find("Main Camera");
        postScript = post.GetComponent<PostVisual>();

        scrollBar = GameObject.Find("BarBG");
        barColor = scrollBar.GetComponent<UnityEngine.UI.Image>();
        BarStartColor = barColor.color;

        GetComponent<SpriteRenderer>().material.color = noteColor;

        if (keyName == "right")
        {
            transform.Rotate(0, 0, 180);
        }

        if (keyName == "a" || keyName == "space")
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }

        if (keyName == "space")
        {

        }
    }

    public void Update()
    {
        interpolate = (noteScript.beatsShownInAdvance - (beatPlay - Conductor.songPositionInBeats)) / noteScript.beatsShownInAdvance;

        if (keyName == "left" || keyName == "right")
        {
            MoveNote();
            InputCheck();
        }

        if (keyName == "space")
        {
            SpaceCheck();
        }

        if (lightningStrike)
        {
            LightningCheck();
        }

        if (woodKnock)
        {
            KnockCheck();
        }




        DestroyOnBeatEnd();





    }

    public void MoveNote()
    {
        transform.position = Vector2.Lerp(
            startPos,
            endPos,
            interpolate
            );
    }

    public void InputCheck()
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
                if (hit2D.collider != null)
                {
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
                            boat.transform.position += new Vector3(0, -1, 0);
                        }
                    }
                } else if (hit2D.collider == null)
                {
                    keyPressed = true;
                    GetComponent<SpriteRenderer>().material.color = missColor;
                    boat.transform.position += new Vector3(0, -1, 0);
                }

            }
            if (Conductor.songPositionInBeats > beatPlay + safety - beatDelay)
            {
                keyPressed = true;
                GetComponent<SpriteRenderer>().material.color = missColor;
                boat.transform.position += new Vector3(0, -1, 0);
            }
        }
    }


    public void SpaceCheck()
    {
        if (!isYellow)
        {
            if (Conductor.songPositionInBeats > beatPlay - safety - beatDelay && Conductor.songPositionInBeats < beatPlay + safety - beatDelay)
            {
                barColor.color = Color.yellow;
                isYellow = true;
            }
        }

        if (!keyPressed)
        {
            if (Input.GetKeyDown(keyName))
            {
                if (Conductor.songPositionInBeats > beatPlay - safety - beatDelay && Conductor.songPositionInBeats < beatPlay + safety - beatDelay)
                {
                    keyPressed = true;
                    barColor.color = hitColor;
                }
            }
        }
        if (!keyPressed)
        {
            if (!isRed)
            {
                if (Conductor.songPositionInBeats > beatPlay + safety / 2 - beatDelay)
                {
                    isRed = true;
                    barColor.color = missColor;
                    boat.transform.position += new Vector3(0, -1, 0);
                }
            }
        }

        if (isRed || keyPressed)
        {
            barColor.color += new Color(0.5f, 0.5f, 0.5f) * Time.deltaTime;
        }
    }

    public void LightningCheck()
    {
        if (Conductor.songPositionInBeats > beatPlay - safety / 4 - beatDelay && Conductor.songPositionInBeats < beatPlay + safety / 4 - beatDelay)
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
        if (Conductor.songPositionInBeats > beatPlay - safety / 4 - beatDelay && Conductor.songPositionInBeats < beatPlay + safety / 4 - beatDelay)
        {
            if (woodKnock)
            {

            }
        }
    }

    public void DrumCheck()
    {
        if (Conductor.songPositionInBeats > beatPlay - safety / 4 - beatDelay && Conductor.songPositionInBeats < beatPlay + safety / 4 - beatDelay)
        {
            if (drumStick)
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


