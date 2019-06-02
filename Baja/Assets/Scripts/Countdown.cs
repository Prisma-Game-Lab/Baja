using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {
    public Text timer;
    public static float laptime = 0;
	// Use this for initialization
	void Start () {
        laptime = -0.02f;
        timer.text = "Timer: ";
	}
	
	// Update is called once per frame
	void Update () {
        timer.text = "Timer: " + (Mathf.Round(laptime*1000f)/1000f);
        laptime += Time.deltaTime;
	}
}
