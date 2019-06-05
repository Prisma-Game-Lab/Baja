using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {
    public Text timer;

	public GameObject CheckPoint;
    public static float laptime = 0;
	// Use this for initialization
	void Start () {
        laptime = -0.02f;
        timer.text = "Timer: ";	
	}
	
	// Update is called once per frame
void Update () {
        timer.text = "Timer: " + (Mathf.Round(laptime*1000f)/1000f) + "\nLap: ";
		if(CheckPoint.transform.GetChild(2).gameObject.activeSelf) {
			timer.text += "1";
		}
		if(CheckPoint.transform.GetChild(3).gameObject.activeSelf) {
			timer.text += "2";
		}
		if(CheckPoint.transform.GetChild(4).gameObject.activeSelf) {
			timer.text += "3";
		}
        laptime += Time.deltaTime;
	}
}

