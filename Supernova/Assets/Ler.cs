using UnityEngine;

public class Ler : MonoBehaviour
{
    private bool PlayerNoTrigger;
    private bool estaLendo = false;
    public GameObject FichaParaLer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Opcional, garante que só o jogador ativa
        {
            PlayerNoTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerNoTrigger = false;
        }
    }

    void Update()
    {
        if (PlayerNoTrigger && Input.GetKeyDown(KeyCode.E))
        {
            estaLendo = !estaLendo; // Alterna entre true e false
            FichaParaLer.SetActive(estaLendo);
            Time.timeScale = estaLendo ? 0 : 1;
        }
    }
}
