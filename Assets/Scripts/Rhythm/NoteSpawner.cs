using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    
    public float[] beatPlay;
    public string[] keyName;
    public bool[] noteLightning;
    public Vector2 beatStart;
    public Vector2 leftBeatEnd;
    public Vector2 rightBeatEnd;
    public Color leftColor;
    public Color rightColor;
    public float beatsShownInAdvance;
    public GameObject notePrefab;

    private int nextIndex = 0;

    void Start()
    {
        
    }



    void Update()
    {
        if (nextIndex < beatPlay.Length && beatPlay[nextIndex] < Conductor.songPositionInBeats + beatsShownInAdvance)
        {
            notePrefab.GetComponent<NoteClass>().beatPlay = beatPlay[nextIndex];
            notePrefab.GetComponent<NoteClass>().keyName = keyName[nextIndex];
            notePrefab.GetComponent<NoteClass>().startPos = beatStart;
            notePrefab.GetComponent<NoteClass>().lightningStrike = noteLightning[nextIndex];
            
            if (keyName[nextIndex] == "left")
            {
                notePrefab.GetComponent<NoteClass>().endPos = leftBeatEnd;
                notePrefab.GetComponent<NoteClass>().noteColor = leftColor;
            }

            if (keyName[nextIndex] == "right")
            {
                notePrefab.GetComponent<NoteClass>().endPos = rightBeatEnd;
                notePrefab.GetComponent<NoteClass>().noteColor = rightColor;
            }

            Instantiate(notePrefab, beatStart, Quaternion.identity);
            nextIndex++;
        }
    }
}
