using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    [SerializeField]float beatTempo;
    [SerializeField] Transform boat;
    Vector3 startVector;
    bool hasStarted;
    // Start is called before the first frame update
    void Start()
    {
        startVector = boat.transform.position - transform.position+Vector3.right*0.5f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) {
            hasStarted = true;
        }


        if (hasStarted) {

            transform.position += startVector * beatTempo/60f/4 * Time.deltaTime;
        }
    }
}
