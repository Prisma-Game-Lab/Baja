using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmit : MonoBehaviour
{
    ParticleSystem particles;
    public WheelDrive wheels;
    public float minRpmToPlay = 10f;
    void Start() {
        particles = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        if(wheels.maxRpm >= minRpmToPlay){
            particles.Play();
        }else{
            particles.Stop();
        }
    }
}
