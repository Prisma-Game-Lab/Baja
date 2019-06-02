using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour {

    public bool FirstLap;
    public bool SecondLap;
    public bool FinalLap;
    public int ObstacleNumber;
    public GameObject gLap;

    [HideInInspector]
    public GameObject FinalPanel;
    [HideInInspector]
    public Text FinalPanelText;

    private static float ResultFirstLap;
    private static float ResultSecondLap;
    private static float ResultFinalLap;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(other.GetComponent<Register>().HowMany == ObstacleNumber-1)
            {
                other.GetComponent<Register>().HowMany++;
                if(FirstLap) // Completou o primeiro lap
                {
                    ResultFirstLap = Countdown.laptime; // Resultado primero lap
                    other.GetComponent<Register>().HowMany = 0;
                    gLap.SetActive(true);
                    this.gameObject.SetActive(false);
                }
                if(SecondLap) // Completou o segundo lap
                {
                    ResultSecondLap = Countdown.laptime; // Resultado segundo lap
                    other.GetComponent<Register>().HowMany = 0;
                    gLap.SetActive(true);
                    this.gameObject.SetActive(false);
                }
                if(FinalLap) // Completou o terceiro lap
                { Time.timeScale = 0f;
                    ResultFinalLap = Countdown.laptime; // Resultado terceiro lap
                    FinalPanelText.text = "\n\nLap1: " + (Mathf.Round(ResultFirstLap*1000f)/1000f) + "\n" +
                                          "Lap2: " + (Mathf.Round(ResultSecondLap*1000f)/1000f) + "\n" +
                                          "Lap3: " + (Mathf.Round(ResultFinalLap*1000f)/1000f);
                    FinalPanel.SetActive(true);
                }
            }
        }
    }
}
