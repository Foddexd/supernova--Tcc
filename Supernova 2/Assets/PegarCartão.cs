using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarCartão : MonoBehaviour
{
    public GameObject CabideComCartao;
    public GameObject CabideSemCartão;
    public GameObject CartãoInventario;
    public GameObject Botao;

    public bool JogadorPerto = false;

    public static bool TemCartao=false;

    public void PegarCartao()
    {
        CabideComCartao.SetActive(false);
        CabideSemCartão.SetActive(true);
        CartãoInventario.SetActive(true);
        TemCartao = true;
        Botao.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            JogadorPerto = true;
            Botao.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            JogadorPerto = false;
            Botao.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (JogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            PegarCartao();
            Botao.SetActive(false);

        }
    }
    
}
