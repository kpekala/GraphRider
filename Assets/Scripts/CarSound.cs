using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{
    AudioSource audioSource;
    public float minPitch = 0.05f;
    public float carSpeedFactor = 0.01f;
    private float pitchFromCar;
     
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = minPitch;
    }
 
    void Update()
    {
        pitchFromCar = (float) Math.Log(0.7 * PlayerController.cc.currentSpeed);
        Debug.Log(pitchFromCar);
        if(pitchFromCar < minPitch)
            audioSource.pitch = minPitch;
        else
            audioSource.pitch = pitchFromCar;
    }
}
