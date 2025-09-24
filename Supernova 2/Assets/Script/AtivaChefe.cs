using UnityEngine;
using UnityEngine.Events;

public class AtivadorPorTrigger : MonoBehaviour
{
    [Header("Objeto a ser ativado")]
    public GameObject objeto1;
    public GameObject objeto2;

    [Header("Código a ser executado")]
    public UnityEvent aoAtivar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objeto1.SetActive(false);
            objeto2.SetActive(false);

            aoAtivar.Invoke();

            
            Destroy(gameObject);
        }
    }
}
