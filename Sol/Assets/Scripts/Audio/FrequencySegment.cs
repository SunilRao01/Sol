using UnityEngine;
using System;
using System.Collections;



public class FrequencySegment  {
    private const int SAMPLE_SIZE = 60;

    private  float[] samples = new float[SAMPLE_SIZE];
    private float average = 0.0f;
    private float sum = 0.0f;
    private float minVal = 3.0f;    //might not be used
    private float maxVal = -3.0f;   //might not be used
    private float prevVal = 0.0f;
    private int sCounter = 0;

    private int loIndex = 0;
    private int hiIndex = 0;
    
    public bool filling = true;
    public float curVal = 0.0f;

    public FrequencySegment(int loIndex, int hiIndex) {
        this.loIndex = loIndex;
        this.hiIndex = hiIndex;
    }

    //returns true if significant change
    public bool add(float[] samples) {
        float sum = getSum(samples);
        return addSample(sum);
    }

    //returns true if significant change
    private bool addSample(float val) {
        curVal = val;

        if (sCounter >= SAMPLE_SIZE) {
            filling = false;
            sCounter = 0;
        }

        //update sum
        if (filling) {
            sum += curVal;
        }
        else {
            sum -= samples[sCounter];
            sum += curVal;
        }

        //update average
        average = sum / SAMPLE_SIZE;

        //fill buffer
        samples[sCounter] = curVal;

        //update min, max
        //if (samples[sCounter] > maxVal) {
        //    maxVal = samples[sCounter];
        //}
        //if (minVal < samples[sCounter]) {
        //    minVal = samples[sCounter];
        //}

        //update counter
        sCounter++;

        //make check
        bool result = false;
        if (!filling) {
            if (curVal > average) {
                if (curVal > average + (CalculateStdDev() * 1.5))
                    result = true;
            }
        }

        prevVal = curVal;
        return result;
    }

    private float CalculateStdDev() {
        float ret = 0.0f;
       
        //Perform the Sum of (value-avg)_2_2
        float sum = 0.0f;
        for(int i = 0; i< SAMPLE_SIZE; i++){
            sum += (float)(Math.Pow(average - samples[i], 2));
        }

        //Put it all together      
        ret = (float)(Math.Sqrt((sum) / (SAMPLE_SIZE)));

        return ret;
    }

    private float getSum(float[] samples) {
        float sum = 0.0f;
        for (int i = loIndex; i <= hiIndex; i++) {
            float curVal = samples[i];
            sum += curVal;

            //update min, max
            if (curVal > maxVal) {
                maxVal = curVal;
            }
            if (curVal < minVal) {
                minVal = curVal;
            }
        }

        return sum;
    }
}
