using UnityEngine;
using System.Collections; // Necessário para usar IEnumerator e corrotinas

public class UsarKitMedico : MonoBehaviour
{
    public GameObject kitNoInventario; // O objeto ativado pelo outro script
    public PlayerHealth playerHealth;
    public GameObject piscaverde;

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

        // Inicia a corrotina para ativar/desativar o efeito visual
        StartCoroutine(AtivarPiscadaVerde());
    }

    IEnumerator AtivarPiscadaVerde()
    {
        piscaverde.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        piscaverde.SetActive(false);
    }
}
