using UnityEngine;
using System.Collections;
using TMPro;

public class UsarKitMedico : MonoBehaviour
{
    public GameObject kitNoInventario; // O objeto ativado pelo outro script
    public PlayerHealth playerHealth;
    public GameObject piscaverde;

    public GameObject texto;

    public float tempoExibicao = 2f;


    void Update()
    {
        if (kitNoInventario.activeSelf && Input.GetKeyDown(KeyCode.V))
        {
            UsarKit();
        }
    }

    void UsarKit()
    {
        kitNoInventario.SetActive(false); // "Consumir" o kit
        playerHealth.currentHealth = playerHealth.maxHealth;
        Debug.Log("Kit médico usado! Vida restaurada.");

        // Atualiza os objetos de vida
        playerHealth.SendMessage("AtualizarIndicadoresDeVida");

        MostrarTexto();

        // Inicia a corrotina para ativar/desativar o efeito visual
        StartCoroutine(AtivarPiscadaVerde());
    }

    IEnumerator AtivarPiscadaVerde()
    {
        piscaverde.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        piscaverde.SetActive(false);
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
