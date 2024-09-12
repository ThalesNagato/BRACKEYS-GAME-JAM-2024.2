using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncedRotation : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Conductor.instance.completedLoops % 2 == 0)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(-50, 50, Conductor.instance.loopPositionInAnalog));
        }

        if (Conductor.instance.completedLoops % 2 == 1)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(50, -50, Conductor.instance.loopPositionInAnalog));
        }


        //Debug.Log(Conductor.instance.loopPositionInAnalog);
    }
}
