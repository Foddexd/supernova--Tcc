using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColocarAlavanca : MonoBehaviour
{
    public GameObject AlavancaVisualQuebrada;
    public GameObject AlavancaVisualCompleta;
    public GameObject AlavancaInventario;
    public bool JogadorPerto = false;

    public GameObject texto;
    public float tempoExibicao = 2f;
    public GameObject textointeragir;
    public GameObject item1;



   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && AlavancaInventario.activeSelf)
        {
            JogadorPerto = true;
            textointeragir.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && AlavancaInventario.activeSelf)
        {
            JogadorPerto = false;
            textointeragir.SetActive(false);
        }
    }

    void Update()
    {
        if (JogadorPerto && Input.GetKeyDown(KeyCode.E) && AlavancaInventario.activeSelf)
        {
            textointeragir.SetActive(false);
            AlavancaVisualQuebrada.SetActive(false);
            AlavancaVisualCompleta.SetActive(true);
            AlavancaInventario.SetActive(false);
            MostrarTexto();
            if (item1 != null) item1.SetActive(false);
            


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
