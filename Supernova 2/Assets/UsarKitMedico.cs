using UnityEngine;

public class UsarKitMedico : MonoBehaviour
{
    public GameObject kitNoInventario; // O objeto ativado pelo outro script
    public PlayerHealth playerHealth;

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
    }
}
