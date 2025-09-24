using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Ler : MonoBehaviour
{
    private bool PlayerNoTrigger;
    private bool estaLendo = false;
    public GameObject FichaParaLer;
    public GameObject botaoInteracao; 

    public GameObject texto;

    

    private void Start()
    {
        if (botaoInteracao != null)
            botaoInteracao.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerNoTrigger = true;
            texto.SetActive(true);
            if (botaoInteracao != null)
                botaoInteracao.SetActive(true); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerNoTrigger = false;
            texto.SetActive(false);
            if (estaLendo)
                AlternarLeitura(); 

            if (botaoInteracao != null)
                botaoInteracao.SetActive(false); 
        }
    }

    void Update()
    {
        if (PlayerNoTrigger && Input.GetKeyDown(KeyCode.E))
        {
            AlternarLeitura();
        }
    }

    
    public void AlternarLeitura()
    {
        estaLendo = !estaLendo;
        FichaParaLer.SetActive(estaLendo);
        Time.timeScale = estaLendo ? 0 : 1;
    }
}
