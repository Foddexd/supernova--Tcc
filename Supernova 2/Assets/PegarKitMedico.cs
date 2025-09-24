using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class PegarKitMedico : MonoBehaviour
{
    public GameObject KitVisual;
    public GameObject KitInventario;
    public bool JogadorPerto = false;

    public GameObject texto;

    public float tempoExibicao = 2f;

    public GameObject textopegar;

  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && KitVisual.activeSelf)
        {
            JogadorPerto = true;
            textopegar.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && KitVisual.activeSelf) 
        {
            JogadorPerto = false;
            textopegar.SetActive(false);

        }
    }

  
    void Update()
    {
        if (JogadorPerto && Input.GetKeyDown(KeyCode.E) && KitVisual.activeSelf)
        {
            textopegar.SetActive(false);
            KitVisual.SetActive(false);
            MostrarTexto();
            KitInventario.SetActive(true);

           
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
