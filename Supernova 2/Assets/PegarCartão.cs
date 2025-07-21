using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PegarCartão : MonoBehaviour
{
    public GameObject CabideComCartao;
    public GameObject CabideSemCartão;
    public GameObject CartãoInventario;
    public GameObject Botao;

    public bool JogadorPerto = false;

    public static bool TemCartao=false;

    public GameObject texto;

    public float tempoExibicao = 2f;

    public GameObject textointeração;

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
        if (other.CompareTag("Player") && CabideComCartao.activeSelf)
        {
            JogadorPerto = true;
            textointeração.SetActive(true) ;
            Botao.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && CabideComCartao.activeSelf)
        {
            JogadorPerto = false;
            textointeração.SetActive(false) ;
            Botao.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (JogadorPerto && Input.GetKeyDown(KeyCode.E) && CabideComCartao.activeSelf)
        {
            PegarCartao();
            textointeração.SetActive(false);
            MostrarTexto();
            Botao.SetActive(false);

        }
    }
    public void MostrarTexto()
    {
        StartCoroutine(ExibirTextoTemporario());
    }
    IEnumerator ExibirTextoTemporario()
    {
        texto.SetActive(true);
        yield return new WaitForSeconds(tempoExibicao);
        texto.SetActive(false);
    }

}
