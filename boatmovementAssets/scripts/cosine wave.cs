using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cosinewave : MonoBehaviour
{
    // Start is called before the first frame update
    public LineRenderer myLineRenderer;
    private int points;
    public float amplitude = 2f;
    public float frequency = 3f;
    public Vector2 xLimits = new Vector2(-12.5f,12.5f);
    private float movementSpeed = 1f;
    //[Range(0,2*Mathf.PI)]
    //public float radians;

    public float bpm;
    private float bps;

    void Start()
    {
        myLineRenderer = GetComponent<LineRenderer>();
        points = 74;
    }
    
    void Draw()
    {

        bps = bpm/60;
        movementSpeed = bps * Mathf.PI;
        float xStart = xLimits.x;
        float Tau = 2* Mathf.PI;
        float xFinish = xLimits.y;
 
        myLineRenderer.positionCount = points;
        for(int currentPoint = 0; currentPoint<points;currentPoint++)
        {
            float progress = (float)currentPoint/(points-1);
            float x = Mathf.Lerp(xStart,xFinish,progress);
            float y = amplitude*Mathf.Cos((Tau*frequency*x)+(Time.timeSinceLevelLoad*movementSpeed));
            myLineRenderer.SetPosition(currentPoint, new Vector3(x,y,0));
        }
    }
 
    void Update()
    {
        Draw();
    }
}
