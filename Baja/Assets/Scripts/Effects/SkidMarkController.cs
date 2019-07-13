using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkidMarkController : MonoBehaviour
{
    private TrailRenderer mark;
    public WheelCollider tyre;
    private Rigidbody carRb;
    public float minSteerAngleToMark = 30.0f; 
    public float minBrakeTorqueToMark = 1.0f; 

    void Start(){
        mark = gameObject.GetComponent<TrailRenderer>();
        carRb = transform.parent.parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(tyre.steerAngle + " " + tyre.brakeTorque);
        mark.emitting = IsCarMoving() && (Mathf.Abs(tyre.steerAngle) > minSteerAngleToMark || tyre.brakeTorque > minBrakeTorqueToMark);
    }

    bool IsCarMoving(){
        return carRb.velocity.magnitude > 0;
    }
}
