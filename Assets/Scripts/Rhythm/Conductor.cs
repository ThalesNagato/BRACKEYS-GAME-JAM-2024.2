using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    public float songBpm;
    public float secPerBeat;
    public float songPosition;
    public static float songPositionInBeats;
    public static float dspSongTime;
    public AudioSource musicSource;
    public float beatsPerLoop;
    public int completedLoops = 0;
    public float loopPositionInBeats;
    public float loopPositionInAnalog;
    public static Conductor instance;


    private void Awake()
    {
        songPositionInBeats = 0;
        instance = this;
    }

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        secPerBeat = 60f / songBpm;
        dspSongTime = (float)AudioSettings.dspTime;
        musicSource.Play();
    }

    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        songPositionInBeats = songPosition / secPerBeat;
        loopPositionInAnalog = loopPositionInBeats / beatsPerLoop;

        if (songPositionInBeats >= (completedLoops + 1) * beatsPerLoop)
        {
            completedLoops++;
        }

        loopPositionInBeats = songPositionInBeats - completedLoops * beatsPerLoop;
        loopPositionInAnalog = loopPositionInBeats / beatsPerLoop;
    }
}
