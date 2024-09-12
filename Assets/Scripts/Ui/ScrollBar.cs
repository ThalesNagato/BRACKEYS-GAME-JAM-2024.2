using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBar : MonoBehaviour
{
    public float barSize;
    public Color hitColor;
    public Color missColor;
    public float fadeSpeed;

    private Vector2 startPosition;

    private int CurrentNote;
    private GameObject currentNote;
    private NoteClass currentNoteClass;
    private Color startColor;
    private float Interpolate = 0;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startColor = GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        ColorFade();

        //Debug.Log(currentNoteClass.interpolate);
        if (currentNote != null)
        {
            if (currentNoteClass.keyName == "left")
            {
                transform.position = Vector2.Lerp(startPosition, new Vector2(startPosition.x - barSize, transform.position.y), currentNoteClass.interpolate);
            } else if (currentNoteClass.keyName == "right")
            {
                transform.position = Vector2.Lerp(startPosition, new Vector2(startPosition.x + barSize, transform.position.y), currentNoteClass.interpolate);
            }
            else
        {
            transform.position = startPosition;
            GetComponent<Image>().color = startColor;
            

        }
        } 

        
    }

    public void GetCurrentNote(GameObject sentNote)
    {
        currentNote = sentNote;
        currentNoteClass = currentNote.GetComponent<NoteClass>();
    }

    public void HitSignafier(bool hit)
    {
        if (hit)
        {
            GetComponent<Image>().color = hitColor;
            Interpolate = 0;
        }
        else
        {
            GetComponent<Image>().color = missColor;
            Interpolate = 0;
        }
        
    }

    public void ColorFade()
    {

        Interpolate += fadeSpeed * Time.deltaTime;

        GetComponent<Image>().color = Color.Lerp(GetComponent<Image>().color, startColor, Interpolate);
    }
}
