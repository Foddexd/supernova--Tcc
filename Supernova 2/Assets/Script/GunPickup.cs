using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public GameObject gunVisual; 
    public PlayerShooting shootingScript;
    public GameObject ArmaInventario;
    public GameObject ArmaChao;
    public GameObject botaoCanvas; 
    public GameObject Porta1;
    public GameObject Porta2;
    public GameObject Botao;

    public GameObject texto;

    private bool playerInRange;

    void Start()
    {
        botaoCanvas.SetActive(false);
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
        shootingScript.EquiparArma();
        gunVisual.SetActive(true);
        ArmaInventario.SetActive(true);
        ArmaChao.SetActive(false);
        botaoCanvas.SetActive(false); 
        Porta1.SetActive(false);
        Porta2.SetActive(false);
        Botao.SetActive(true);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            texto.SetActive(true);
            botaoCanvas.SetActive(true); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            texto.SetActive(false);
            botaoCanvas.SetActive(false); 
        }
    }
}
