using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AudioSpectrum : MonoBehaviour {
    AudioSource audio;

    private List<Dancer> dancers = new List<Dancer>();
    private Dictionary<int, FrequencySegment> segments = new Dictionary<int, FrequencySegment>();

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();    
	}
	
	// Update is called once per frame
	void Update () {
        //sampling rate = 24000 
        float[] spectrum = new float[1024];
        audio.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        foreach(var dancer in dancers){
            dancer.dance(segments[dancer.segment].add(spectrum));
        }
	}

    public void addDancer(Dancer dancer, int segment){
        dancers.Add(dancer);

        try {
            segments.Add(segment, FrequencySegmentFactory.MakeSegment(segment));
        }
        catch (ArgumentException) {
            Debug.Log("Segment already made for other dancer");
        }
    }
}
