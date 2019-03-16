using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour {

    public bool IsFinal;
    public int ObstacleNumber;

    [HideInInspector]
    public GameObject FinalPanel;
    [HideInInspector]
    public Text FinalPanelText;
    [HideInInspector]
    public GameObject Countdown;

    private float result;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(other.GetComponent<Register>().HowMany == ObstacleNumber-1)
            {
                other.GetComponent<Register>().HowMany++;
                //Debug.Log(ObstacleNumber);
                if(IsFinal)
                { Time.timeScale = 0f;
                    result = Countdown.GetComponent<Countdown>().laptime;
                    FinalPanelText.text = "Time: " + Mathf.Round(result);
                    FinalPanel.SetActive(true);
                }
            }
        }
    }
}
