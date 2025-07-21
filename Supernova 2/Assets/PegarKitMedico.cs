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

    // Start is called before the first frame update

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
