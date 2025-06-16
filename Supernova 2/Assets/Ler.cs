using UnityEngine;
using UnityEngine.UI;

public class Ler : MonoBehaviour
{
    private bool PlayerNoTrigger;
    private bool estaLendo = false;
    public GameObject FichaParaLer;
    public GameObject botaoInteracao; // Bot�o de UI que ser� ativado/desativado

    private void Start()
    {
        if (botaoInteracao != null)
            botaoInteracao.SetActive(false); // Garante que o bot�o comece desativado
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerNoTrigger = true;
            if (botaoInteracao != null)
                botaoInteracao.SetActive(true); // Mostra o bot�o quando o jogador entra
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerNoTrigger = false;
            if (estaLendo)
                AlternarLeitura(); // Sai da leitura ao sair da �rea

            if (botaoInteracao != null)
                botaoInteracao.SetActive(false); // Esconde o bot�o
        }
    }

    void Update()
    {
        if (PlayerNoTrigger && Input.GetKeyDown(KeyCode.E))
        {
            AlternarLeitura();
        }
    }

    // M�todo p�blico para ser chamado pelo bot�o mobile
    public void AlternarLeitura()
    {
        estaLendo = !estaLendo;
        FichaParaLer.SetActive(estaLendo);
        Time.timeScale = estaLendo ? 0 : 1;
    }
}
