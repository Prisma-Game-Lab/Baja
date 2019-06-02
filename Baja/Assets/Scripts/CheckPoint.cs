using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour {

    public bool IsFinal;
    public bool Lap1;
    public bool Lap2;
    public int ObstacleNumber;
    public GameObject gLap;

    [HideInInspector]
    public GameObject FinalPanel;
    [HideInInspector]
    public Text FinalPanelText;

    private float result1;
    private float result2;
    private float result3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(other.GetComponent<Register>().HowMany == ObstacleNumber-1)
            {
                other.GetComponent<Register>().HowMany++;
                if(Lap1)
                {
                    result1 = Countdown.laptime;
                    other.GetComponent<Register>().HowMany = 0;
                    gLap.SetActive(true);
                    this.gameObject.SetActive(false);
                }
                if(Lap2)
                {
                    result2 = Countdown.laptime;
                    other.GetComponent<Register>().HowMany = 0;
                    gLap.SetActive(true);
                    this.gameObject.SetActive(false);
                }
                if(IsFinal)
                { Time.timeScale = 0f;
                    result3 = Countdown.laptime;
                    FinalPanelText.text = "\n\nLap1: " + (Mathf.Round(result1*1000f)/1000f) + "\n" +
                                          "Lap2: " + (Mathf.Round(result2*1000f)/1000f) + "\n" +
                                          "Lap3: " + (Mathf.Round(result3*1000f)/1000f);
                    FinalPanel.SetActive(true);
                }
            }
        }
    }
}
