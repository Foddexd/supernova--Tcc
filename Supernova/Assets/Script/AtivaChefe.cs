using UnityEngine;
using UnityEngine.Events;

public class AtivadorPorTrigger : MonoBehaviour
{
    [Header("Objeto a ser ativado")]
    public GameObject objetoParaAtivar;

    [Header("C�digo a ser executado")]
    public UnityEvent aoAtivar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (objetoParaAtivar != null)
                objetoParaAtivar.SetActive(true);

            aoAtivar.Invoke();

            // Destroi o objeto que cont�m este script (e o trigger)
            Destroy(gameObject);
        }
    }
}
