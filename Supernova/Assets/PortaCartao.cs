using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaCartao : MonoBehaviour
{
    public bool JogadorPerto;
    
    public GameObject PortaFechada1;
    public GameObject PortaFechada2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            JogadorPerto = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            JogadorPerto = false;
        }
    }
    private void Update()
    {
        if (JogadorPerto && Input.GetKeyDown(KeyCode.E) && PegarCartão.TemCartao == true )
        {
            
            PortaFechada1.SetActive(false);
            PortaFechada2.SetActive(false);
        }
    }

    //Outro metodo
    //private bool portaJaAberta = false;

    // private void Update()
    //{
    //   if (JogadorPerto && Input.GetKeyDown(KeyCode.E) && PegarCartão.TemCartao && !portaJaAberta)
    //  {
           
    //        PortaFechada1.SetActive(false);
      //      PortaFechada2.SetActive(false);
      //      portaJaAberta = true;
      //  }
  //  }
}
