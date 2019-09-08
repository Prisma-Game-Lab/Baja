using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownBeforeGame : MonoBehaviour
{
    public Text countdown;
    public float numero;
    static public bool acabou = false;
    void Start()
    {
        numero = 4;
    }

    
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if(MenuManager.AfterCountdown) {
            countdown.gameObject.SetActive(true);
            numero -= Time.deltaTime;
            countdown.text = Mathf.RoundToInt((numero-1)).ToString();
            if(numero - 1 <= 1) {
                countdown.text = "Start!";
                acabou = true;
            }
            if(numero -1 <= 0) {
                countdown.gameObject.SetActive(false);
            }
        }
    }
}
