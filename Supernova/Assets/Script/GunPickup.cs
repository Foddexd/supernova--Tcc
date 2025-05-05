using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public GameObject gunVisual; // Para ativar no jogador
    public PlayerShooting shootingScript;
    public GameObject ArmaInventario;
    public GameObject ArmaChão;

    private bool playerInRange;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ColetarArma();
        }
    }

    // Este é o método que o botão chama diretamente
    public void PegarArma()
    {
        if (playerInRange)
        {
            ColetarArma();
        }
    }

    // Essa é a lógica comum que ambos chamam
    private void ColetarArma()
    {
        shootingScript.temArma = true;
        gunVisual.SetActive(true); // Ativa a arma visual no jogador
        ArmaInventario.SetActive(true);
        ArmaChão.SetActive(false); // Some com a arma do chão
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
