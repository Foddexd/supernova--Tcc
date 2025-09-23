using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PegarAlavanca : MonoBehaviour
{
    public GameObject AlavancaVisual;
    public GameObject AlavancaInventario;
    public bool JogadorPerto = false;

    public GameObject texto;
    public float tempoExibicao = 2f;
    public GameObject textopegar;

   
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && AlavancaVisual.activeSelf)
        {
            JogadorPerto = true;
            textopegar.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && AlavancaVisual.activeSelf)
        {
            JogadorPerto = false;
            textopegar.SetActive(false);
        }
    }

    void Update()
    {
        if (JogadorPerto && Input.GetKeyDown(KeyCode.E) && AlavancaVisual.activeSelf)
        {
            textopegar.SetActive(false);
            AlavancaVisual.SetActive(false);
            AlavancaInventario.SetActive(true);

            MostrarTexto();

              
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
