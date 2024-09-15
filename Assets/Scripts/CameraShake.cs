using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;
    // Start is called before the first frame update

    private void Awake() => Instance = this;

    private void OnShake(float duration, float strength) {

        transform.DOShakePosition(duration, strength);
        transform.DOShakeRotation(duration, strength);
    }

    public static void Shake(float duration, float strength) {

        Instance.OnShake(duration, strength);
    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) {

            //Camera.main.transform
            Shake(1,1);


        }
    }
}
