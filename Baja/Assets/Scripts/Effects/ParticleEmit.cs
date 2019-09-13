using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmit : MonoBehaviour
{
    ParticleSystem particles;
    void Start() {
        particles = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        /*if(CARRO TA SE MOVENDO){
            particles.Play();
        }else{
            particles.Stop();
        }*/
    }
}
