using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public float beatsShownInAdvance;
    public float[] beatPlay;
    public Vector2[] beatStart;
    public Vector2[] beatEnd;
    int nextIndex = 0;
    public GameObject notePrefab;
   
    


    void Start()
    {
        
    }



    void Update()
    {
        if (nextIndex < beatPlay.Length && beatPlay[nextIndex] < Conductor.songPositionInBeats + beatsShownInAdvance)
        {
            notePrefab.GetComponent<NoteClass>().beatPlay = beatPlay[nextIndex];
            notePrefab.GetComponent<NoteClass>().startPos = beatStart[nextIndex];
           // Debug.Log(notePrefab.GetComponent<NoteClass>().startPos);
            notePrefab.GetComponent<NoteClass>().endPos = beatEnd[nextIndex];

            Instantiate(notePrefab, beatStart[nextIndex], Quaternion.identity);

            


            nextIndex++;
        }
        //Debug.Log(Conductor.songPositionInBeats);
    }
}
