using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class NoteClass : MonoBehaviour
{
    public float beatPlay;
        public Vector2 startPos;
        public Vector2 endPos;
        public GameObject noteSpawner;
        public GameObject boat;
        private NoteSpawner noteScript;
        private BoatMovement boatScript;


    public void Start()
    {
        noteSpawner = GameObject.Find("Note Spawner");
        noteScript = noteSpawner.GetComponent<NoteSpawner>();
        boat = GameObject.Find("Boat");
        boatScript = boat.GetComponent<BoatMovement>();
        
       
    }


    public void Update()
    {
        float interpolate = (noteScript.beatsShownInAdvance - (beatPlay - Conductor.songPositionInBeats)) / noteScript.beatsShownInAdvance;
        //UnityEngine.Debug.Log(noteScript.beatsShownInAdvance + "_" + beatPlay + "_" + Conductor.songPositionInBeats + "_" + noteScript.beatsShownInAdvance + "_" + interpolate);
        transform.position = Vector2.Lerp(
            startPos,
            endPos,
            interpolate
            );

        if (Input.GetKeyDown(KeyCode.Space))
        {
            


            if (Conductor.songPositionInBeats > beatPlay - 0.5f - 2 && Conductor.songPositionInBeats < beatPlay + 0.5f - 2)
            {
                UnityEngine.Debug.Log("test");
                Destroy(gameObject);
            }
        }

        if (Conductor.songPositionInBeats > beatPlay - 0.5f - 2 && Conductor.songPositionInBeats < beatPlay + 0.5f - 2)
        {
            boatScript.RotateSignafier(true);
        } else
        {
            boatScript.RotateSignafier(false);
        }


    }

    public void OnTriggerStay2D(Collider2D collision)
    {
       

        
    }
}
