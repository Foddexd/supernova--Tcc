using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public GameObject gunVisual; // Para ativar no jogador
    public PlayerShooting shootingScript;
    public GameObject ArmaInventario;
    public GameObject ArmaChão;
    public GameObject botaoCanvas; // <-- Referência ao botão do Canvas
    public GameObject Porta1;
    public GameObject Porta2;
    public GameObject Botao;


    private bool playerInRange;

    void Start()
    {
        botaoCanvas.SetActive(false); // Garante que comece desativado
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ColetarArma();
        }
    }

    public void PegarArma()
    {
        if (playerInRange)
        {
            ColetarArma();
        }
    }

    private void ColetarArma()
    {
        shootingScript.temArma = true;
        gunVisual.SetActive(true);
        ArmaInventario.SetActive(true);
        ArmaChão.SetActive(false);
        botaoCanvas.SetActive(false); // Esconde o botão após pegar a arma
        Porta1.SetActive(false);
        Porta2.SetActive(false);
        Botao.SetActive(true);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            botaoCanvas.SetActive(true); // Mostra o botão quando se aproxima
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            botaoCanvas.SetActive(false); // Esconde o botão ao sair
        }
    }
}
