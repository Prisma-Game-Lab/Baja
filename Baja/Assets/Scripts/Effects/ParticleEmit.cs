using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmit : MonoBehaviour
{
    public ParticleSystem[] particles;
    public WheelDrive wheels;
    public float minRpmToPlay = 10f;
    void Update()
    {
        if(wheels.maxRpm >= minRpmToPlay){
            foreach(var particle in particles) particle.Play();
        }else{
            foreach(var particle in particles) particle.Stop();
        }
    }
}
