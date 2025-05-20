using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarCartão : MonoBehaviour
{
    public GameObject CabideComCartao;
    public GameObject CabideSemCartão;
    public GameObject CartãoInventario;

    public bool JogadorPerto = false;

    public static bool TemCartao=false;
    

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
    // Update is called once per frame
    void Update()
    {
        if (JogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            CabideComCartao.SetActive(false);
            CabideSemCartão.SetActive(true);
            CartãoInventario.SetActive(true);  
            TemCartao = true;
        }
    }
}
