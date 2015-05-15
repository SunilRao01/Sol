using UnityEngine;
using System.Collections;

public class AudioSpectrum : MonoBehaviour {
    AudioSource audio;
    //test light
    public Light lowLight;
    public Light midLight;
    public Light hiLight;

    private FrequencySegment lowFreq = new FrequencySegment();
    private FrequencySegment midFreq = new FrequencySegment();
    private FrequencySegment hiFreq = new FrequencySegment();

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();    
	}
	
	// Update is called once per frame
	void Update () {
        float[] spectrum = new float[1024];
        audio.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        //sampling rate = 24000 

        //0 - 150 hz
        float lowVal = getSum(0, 5, spectrum);
        
        //300 - ~420hz
        float midVal = getSum(13, 18, spectrum);
        //1000 - 1123
        float HiVal = getSum(43, 48, spectrum);

        bool lowResult = lowFreq.addSample(lowVal);
        bool midResult = midFreq.addSample(midVal);
        bool hiResult = hiFreq.addSample(HiVal);

        //make check
        if(!lowFreq.filling){
            if(lowResult){
                lowLight.intensity = 8;
             }
            else {
                lowLight.intensity = 0;
            }
        }

        if (!midFreq.filling) {
            if (midResult) {            
                midLight.intensity = 8;
            }
            else {
                midLight.intensity = 0;
            }
        }

        if (!hiFreq.filling) {
            if (hiResult) {
                hiLight.intensity = 8;
            }
            else {
                hiLight.intensity = 0;
            }
        }

        // sample demo stuff used for reference, will delete later
        int i = 1;
        float max = 0.0f;
        int maxIndex = 0;
        while (i < 1023) {
            if(spectrum[i] > max){
                max = spectrum[i];
                maxIndex = i;
            }
            Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.yellow);
            i++;
        }
	}

    private float getSum(int lo, int hi, float[] samples) {
        float sum = 0.0f;
        for (int i = lo; i <= hi; i++) {
            sum += samples[i];
        }

        return sum;
    }
}
