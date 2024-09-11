using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{

    public float boatOffset;
    private int CurrentNote;
    private GameObject currentNote;
    private NoteClass currentNoteClass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentNote != null)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, currentNote.transform.position.y + boatOffset), currentNoteClass.interpolate / 4);
        }
        
    }

    public void RotateSignafier(bool rotate)
    {
        if (rotate)
        {
            transform.Rotate(0, 0, 10f * Time.deltaTime);
        }
    
    }

    public void BoatStabilize()
    {
        transform.Rotate(0, 0, -5);
    }

    public void GetCurrentNote(GameObject sentNote)
    {
        currentNote = sentNote;
        currentNoteClass = currentNote.GetComponent<NoteClass>();
    }
    
}
