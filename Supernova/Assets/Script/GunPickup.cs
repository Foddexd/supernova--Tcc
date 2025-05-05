using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public GameObject gunVisual; // Para ativar no jogador
    public PlayerShooting shootingScript;
    public GameObject ArmaInventario;
    public GameObject ArmaCh�o;

    private bool playerInRange;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ColetarArma();
        }
    }

    // Este � o m�todo que o bot�o chama diretamente
    public void PegarArma()
    {
        if (playerInRange)
        {
            ColetarArma();
        }
    }

    // Essa � a l�gica comum que ambos chamam
    private void ColetarArma()
    {
        shootingScript.temArma = true;
        gunVisual.SetActive(true); // Ativa a arma visual no jogador
        ArmaInventario.SetActive(true);
        ArmaCh�o.SetActive(false); // Some com a arma do ch�o
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
