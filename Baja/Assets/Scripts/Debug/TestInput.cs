using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    public string InputToTest;

    // Update is called once per frame
    void Update()
    {
        if(ControllerDetector.GetButtonDown(InputToTest) || ControllerDetector.GetButton(InputToTest)) Debug.Log(InputToTest + ": " + ControllerDetector.GetButtonDown(InputToTest));
    }
}
