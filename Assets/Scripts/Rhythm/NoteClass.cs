using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class NoteClass : MonoBehaviour
{
    public float beatPlay;
        public Vector2 startPos;
        public Vector2 endPos;
         public string keyName;
    public Color noteColor;
        
        public float safety = 0.5f;
        public float beatDelay = 2;
        public float endZone;

        public float interpolate;
        public GameObject noteSpawner;
        public GameObject boat;
        public GameObject scrollBar;
        private NoteSpawner noteScript;
        private BoatMovement boatScript;
        private ScrollBar barScript;

        private bool noteHit = false;
        


    public void Start()
    {
        noteSpawner = GameObject.Find("Note Spawner");
        noteScript = noteSpawner.GetComponent<NoteSpawner>();

        boat = GameObject.Find("Boat");
        boatScript = boat.GetComponent<BoatMovement>();
        boatScript.GetCurrentNote(gameObject);

        scrollBar = GameObject.Find("Value");
        barScript = scrollBar.GetComponent<ScrollBar>();
        barScript.GetCurrentNote(gameObject);

        GetComponent<SpriteRenderer>().material.color = noteColor;
        
       
    }


    public void Update()
    {
        interpolate = (noteScript.beatsShownInAdvance - (beatPlay - Conductor.songPositionInBeats)) / noteScript.beatsShownInAdvance;
        //UnityEngine.Debug.Log(noteScript.beatsShownInAdvance + "_" + beatPlay + "_" + Conductor.songPositionInBeats + "_" + noteScript.beatsShownInAdvance + "_" + interpolate);
        transform.position = Vector2.Lerp(
            startPos,
            endPos,
            interpolate
            );

        if (Input.GetKeyDown(keyName))
        {
            


            if (Conductor.songPositionInBeats > beatPlay - safety - beatDelay && Conductor.songPositionInBeats < beatPlay + safety - beatDelay)
            {
                noteHit = true;
                boatScript.BoatStabilize();
                GetComponent<SpriteRenderer>().material.color = Color.white;
                barScript.HitSignafier(true);

            } else
            {
                barScript.HitSignafier(false);
            }
        } else if (Input.anyKeyDown) 
        {
            barScript.HitSignafier(false);
        }


        if (!noteHit)
        {
            if (Conductor.songPositionInBeats > beatPlay - 0.5f - 2 && Conductor.songPositionInBeats < beatPlay + 0.5f - 2)
            {
                boatScript.RotateSignafier(true);
            }
            else
            {
                boatScript.RotateSignafier(false);
            }
        }
        

        if(transform.position.x < endZone)
        {
            Destroy(gameObject);
        }


    }

    
}
