using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinhaDeChegada : MonoBehaviour
{
    // ==== Referências externas  ==== 
    public Countdown countdown;

    // ==== Variáveis públicas ("GD tools") ==== 
    [Tooltip("O número de voltas que o jogador deve completar para finalizar o circuito")]
    public int numVoltasNecessárias;

    // ==== Atributos internos ==== 
    private List<EtapaPista> etapasPista;   // Lista de scripts das etapas da pista
    private int numVoltasCompletas;

    // ==== Funções ==== 
    private void Start()
    {
        etapasPista = new List<EtapaPista>();
        // Pega todos os scripts dos GameObjects de etapas da pista e os salva
        for(int i = 0 ; i < transform.childCount ; i++)
        {
            etapasPista.Add(transform.GetChild(i).GetComponent<EtapaPista>());
        }
    }

    // Ao passar pela linha de chegada, verifica se o jogador passou por todas as etapas da pista
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // Conta o número de etapas que o player passou
            int numEtapasPassadas = 0;
            foreach(EtapaPista etapa in etapasPista)
            {
                if (etapa.playerPassouAqui)
                {
                    numEtapasPassadas++;
                }
            }
            // Se o jogador passou por todas as etapas da pista, segue para a próxima volta
            if (numEtapasPassadas == etapasPista.Count)
            {
                numVoltasCompletas++;
                foreach (EtapaPista etapa in etapasPista)
                {
                    etapa.playerPassouAqui = false;
                }
                countdown.CompletaVolta(numVoltasCompletas);
                
                // Se o jogador tiver completado todas as voltas necessárias, termina o jogo
                if(numVoltasCompletas == numVoltasNecessárias)
                {
                    countdown.CompletaCircuito();
                }
            }
        }
    }
}
