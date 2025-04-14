using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public GameObject gunVisual; // Para ativar no jogador
    public PlayerShooting shootingScript;

    private bool playerInRange;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            shootingScript.temArma = true;
            gunVisual.SetActive(true); // Ativa a arma visual no jogador
            Destroy(gameObject); // Some com a arma do chão
        }
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
