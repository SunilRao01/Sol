using UnityEngine;
using System.Collections;

public class SimpleLights : Dancer {
    Light light;

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
        }
        else {
            light.intensity = 0;
        }
    }
}
