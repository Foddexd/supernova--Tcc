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

    private AmmoManager ammoManager;

    private void Start()
    {
        // Tenta encontrar o AmmoManager na cena
        ammoManager = FindObjectOfType<AmmoManager>();
        if (ammoManager == null)
        {
            Debug.LogWarning("PegarBalas: Nenhum AmmoManager encontrado.");
        }
    }

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

    void Update()
    {
        if (JogadorPerto && Input.GetKeyDown(KeyCode.E) && BalaVisual.activeSelf)
        {
            textopegar.SetActive(false);
            BalaVisual.SetActive(false);
            MostrarTexto();

            // Adiciona um cartucho ao AmmoManager
            if (ammoManager != null)
            {
                ammoManager.AdicionarCartucho();
            }
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
