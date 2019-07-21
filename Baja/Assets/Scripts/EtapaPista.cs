using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtapaPista : MonoBehaviour
{
    public bool playerPassouAqui;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerPassouAqui = true;
        }
    }
}
