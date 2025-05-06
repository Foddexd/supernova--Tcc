using UnityEngine;

public class BotaoInteracao : MonoBehaviour
{
    public GameObject objetoParaDesativar;
    public GameObject objetoParaAtivar;

    private bool jogadorPerto = false;
    private bool alternado = false;
    public GameObject botaoCanvas;

    void Start()
    {
        botaoCanvas.SetActive(false); // Garante que comece desativado
    }

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            AlternarObjetos();
        }
    }

    // Esse método pode ser chamado pelo botão do Canvas
    public void InteragirComBotao()
    {
        if (jogadorPerto)
        {
            AlternarObjetos();
        }
    }

    // A lógica de alternar ativação/desativação
    private void AlternarObjetos()
    {
        alternado = !alternado;
        objetoParaDesativar.SetActive(!alternado);
        objetoParaAtivar.SetActive(alternado);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
            botaoCanvas.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
            botaoCanvas.SetActive(false);
        }
    }
}
