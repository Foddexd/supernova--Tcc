using UnityEngine;
using UnityEngine.UI;

public class Ler : MonoBehaviour
{
    private bool PlayerNoTrigger;
    private bool estaLendo = false;
    public GameObject FichaParaLer;
    public GameObject botaoInteracao; // Botão de UI que será ativado/desativado

    private void Start()
    {
        if (botaoInteracao != null)
            botaoInteracao.SetActive(false); // Garante que o botão comece desativado
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerNoTrigger = true;
            if (botaoInteracao != null)
                botaoInteracao.SetActive(true); // Mostra o botão quando o jogador entra
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerNoTrigger = false;
            if (estaLendo)
                AlternarLeitura(); // Sai da leitura ao sair da área

            if (botaoInteracao != null)
                botaoInteracao.SetActive(false); // Esconde o botão
        }
    }

    void Update()
    {
        if (PlayerNoTrigger && Input.GetKeyDown(KeyCode.E))
        {
            AlternarLeitura();
        }
    }

    // Método público para ser chamado pelo botão mobile
    public void AlternarLeitura()
    {
        estaLendo = !estaLendo;
        FichaParaLer.SetActive(estaLendo);
        Time.timeScale = estaLendo ? 0 : 1;
    }
}
