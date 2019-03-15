using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour {

    public float aceleracao = 0;
    public float velocidade = 0;
    public float tempo = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        velocidade = (velocidade + aceleracao*tempo)/100;

        transform.Translate(Vector3.right * velocidade);

        if(aceleracao > 0)
        {
            tempo += Time.deltaTime;
        }

        if(aceleracao <= 0)
        {
            tempo = 0.00000000000001f;
        }

		if(Input.GetKey(KeyCode.UpArrow))
        {
            aceleracao = aceleracao + tempo/60;
        }
        else
        {
            if(velocidade > 0)
            {
                aceleracao = -0.000005f;
            }
            else
            {
                aceleracao = 0;
            }
        }
	}
}
