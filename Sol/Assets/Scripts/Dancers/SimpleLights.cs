using UnityEngine;
using System.Collections;

public class SimpleLights : Dancer {
    Light light;
    int count = 0;

	// Use this for initialization
	void Start () {
        light = this.GetComponent<Light>();
        init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void dance(bool results) {
        if (results) {
            light.intensity = 8;

            if (segment == 0) {
                Debug.Log(count);
                 count++;
            }
        }
        else {
            light.intensity = 0;
        }
    }
}
