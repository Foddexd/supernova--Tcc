using UnityEngine;

public class BotaoInteracao : MonoBehaviour
{
    public GameObject objetoParaDesativar;
    public GameObject objetoParaAtivar;

    private bool jogadorPerto = false;
    private bool alternado = false;

    void Update()
    {
        if (jogadorPerto && Input.GetKeyDown(KeyCode.E))
        {
            alternado = !alternado;

            objetoParaDesativar.SetActive(!alternado);
            objetoParaAtivar.SetActive(alternado);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorPerto = false;
        }
    }
}
