using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    // ==== Referências externas  ==== 
    public GameObject finalPanel;
    public GameObject HUD;

    // ==== Atributos internos ==== 
    private Text finalPanelText;
    public static float laptime = 0;
    private static List<float> resultadosVoltas;
    private int numVoltaAtual = 1;
    private Text timer;

    // ==== Funções ==== 
    void Start () {
        resultadosVoltas = new List<float>();
        finalPanelText = finalPanel.transform.GetChild(1).GetComponent<Text>();
        timer = HUD.transform.GetChild(0).GetComponent<Text>();

        laptime = -0.02f;
        timer.text = "Timer: ";

    }
	
    void Update () {
        timer.text = $"Timer: " + ArredondaTempo(laptime) + 
                    "\nLap: " + numVoltaAtual;
		
        laptime += Time.deltaTime;
	}

    // Arredonda o float do tempo para reduzir o número de casas decimais
    public float ArredondaTempo(float tempoOriginal)
    {
        return (Mathf.Round(tempoOriginal * 1000f) / 1000f);
    }

    // Salva o valor do cronômetro e o reseta
    public void CompletaVolta(int numVolta)
    {
        resultadosVoltas.Add(laptime);
        laptime = 0f;
        numVoltaAtual = numVolta + 1;
    }

    // Apresenta os resultados do jogador e dá a opção de retornar ao menu ou jogar novamente
    public void CompletaCircuito()
    {
        int numVolta = 0;
        foreach(float resultadoVolta in resultadosVoltas)
        {
            finalPanelText.text = string.Concat(finalPanelText.text, (numVolta+1)+"ª volta: " + ArredondaTempo(resultadosVoltas[numVolta]) + "\n");
            numVolta++;
        }
        HUD.SetActive(false);
        finalPanel.SetActive(true);
    }
}

