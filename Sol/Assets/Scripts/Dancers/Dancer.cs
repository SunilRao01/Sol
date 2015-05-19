using UnityEngine;
using System.Collections;

public class Dancer : MonoBehaviour {
    protected AudioSpectrum audioSpectrum;
    public int segment = 0;

    public virtual void dance(bool results) {
        //do stuff
    }

    public virtual void init(){
        audioSpectrum = GameObject.Find("Main Camera").GetComponent<AudioSpectrum>();
        audioSpectrum.addDancer(this, segment);
    }
}
