using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class PegarBalas : MonoBehaviour
{
    public GameObject BalaVisual;
    public GameObject BalaInventario;
    public bool JogadorPerto = false;

    public GameObject texto;

    public float tempoExibicao = 2f;

    public GameObject textopegar;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && BalaVisual.activeSelf)
        {
            JogadorPerto = true;
            textopegar.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && BalaVisual.activeSelf)
        {
            JogadorPerto = false;
            textopegar.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (JogadorPerto && Input.GetKeyDown(KeyCode.E) && BalaVisual.activeSelf)
        {
            textopegar.SetActive(false);
            BalaVisual.SetActive(false);
            MostrarTexto();
            BalaInventario.SetActive(true);


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
