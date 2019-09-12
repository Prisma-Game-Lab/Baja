using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;
using Luminosity.IO;

public class ControllerDetector : MonoBehaviour
{
    private int numControllers = 0;

    // Update is called once per frame
    void Update()
    {
     if(Input.GetJoystickNames().Length != numControllers) UpdateControllers();   
    }

    void UpdateControllers(){
        numControllers = Input.GetJoystickNames().Length;
        if(numControllers > 0){
            string name = Input.GetJoystickNames()[0]; //guarda nome do controle 1
            if(name.ToLower().Contains("xbox one")){ //checa se é controle do xbox one (o ToLower é pra evitar problemas com case sensitive)
                InputManager.SetControlScheme("XboxOne", PlayerID.One);
            }
            else if(name.ToLower().Contains("playstation 4") || name.ToLower().Contains("wireles")){ //checa se é controle do xbox one (o ToLower é pra evitar problemas com case sensitive)
                InputManager.SetControlScheme("PS4", PlayerID.One);
                name.ToLower().Contains("wireless");
            }
            else
            { //se não for, usa o esquema de xbox/ps3
                InputManager.SetControlScheme("PS3/XBOX360", PlayerID.One);
            }
        }
        else{ //não há controles conectados
            InputManager.SetControlScheme("Teclado", PlayerID.One);
            InputManager.SetControlScheme("Teclado", PlayerID.Two);
        }
    }


    public static bool GetButton(string button){
        return InputManager.GetButton(button, PlayerID.One) || InputManager.GetButton(button, PlayerID.Two);
    }

    public static bool GetButtonDown(string button){
        return InputManager.GetButtonDown(button, PlayerID.One) || InputManager.GetButtonDown(button, PlayerID.Two);
    }

    public static float GetAxis(string button){
        float inputController = InputManager.GetAxis(button, PlayerID.One);
        float inputKeyboard = InputManager.GetAxis(button, PlayerID.Two);
        return Mathf.Abs(inputController) > Mathf.Abs(inputKeyboard) ? inputController : inputKeyboard;
    }
}
