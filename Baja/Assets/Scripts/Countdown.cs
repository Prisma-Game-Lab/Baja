using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {
    public bool CanLose;
    public Text timer;
    public float laptime = 120;
	// Use this for initialization
	void Start () {
        timer.text = "Countdown: ";
	}
	
	// Update is called once per frame
	void Update () {
        timer.text = "Countdown: " + Mathf.Round(laptime);
        laptime -= Time.deltaTime;
        //Debug.Log(laptime);
        if (laptime < 0)
        { laptime = 0f;
            if (CanLose)
            { Time.timeScale = 0.0f; }
        }
	}
}
