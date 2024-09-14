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
    private bool goingLeft;
    private bool leftCheck = false;
    private bool noteCheck = false;

    void Start()
    {
        startPosition = transform.position;
        startColor = GetComponent<Image>().color;
    }

    void Update()
    {
        ColorFade();

        if (currentNote != null)
        {
            if (!leftCheck)
            {
                if (currentNoteClass.keyName == "left")
                {
                    goingLeft = true;
                    leftCheck = true;
                }
                else if (currentNoteClass.keyName == "right")
                {
                    goingLeft = false;
                    leftCheck = true;
                }
            }
            if (goingLeft)
            {
                transform.position = Vector2.Lerp(startPosition, new Vector2(startPosition.x - barSize, transform.position.y), currentNoteClass.interpolate);
            }
            else if (!goingLeft)
            {
                transform.position = Vector2.Lerp(startPosition, new Vector2(startPosition.x + barSize, transform.position.y), currentNoteClass.interpolate);
            }
            else
            {
                Destroy(gameObject);
                transform.position = startPosition;
                GetComponent<Image>().color = startColor;
            }
        }
    }

    public void GetCurrentNote(GameObject sentNote)
    {
        if (!noteCheck)
        {
            currentNote = sentNote;
            currentNoteClass = currentNote.GetComponent<NoteClass>();
            noteCheck = true;
        }
        Debug.Log(noteCheck);
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
