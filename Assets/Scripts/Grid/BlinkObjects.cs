using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkObjects : MonoBehaviour
{
    public float rate;
    public bool isIncreasing;
    void Update()
    {
        Color color = GetComponent<Renderer>().material.color;
        if(isIncreasing==false)
        {
            color.a += rate;
            if(color.a >= 225)
                isIncreasing=true;
        }
        else if(isIncreasing==true)
        {
            color.a -= rate;
            if(color.a<=20)
                isIncreasing=false;
        }
    GetComponent<Renderer>().material.color = color;
    }
    
}
