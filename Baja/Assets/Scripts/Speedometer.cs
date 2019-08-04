using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    public Rigidbody car;
    public float maxSpeed = 100;
    public RectTransform speedometer;

    float speedPercentage = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedPercentage = car.velocity.magnitude/maxSpeed;
        speedometer.rotation = Quaternion.Euler(0,0,Mathf.Lerp(90,-90,speedPercentage));
    }
}
