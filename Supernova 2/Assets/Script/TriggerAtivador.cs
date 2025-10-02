using UnityEngine;

public class TriggerActivator : MonoBehaviour
{
    public GameObject item1;
    public GameObject item2;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Garante que apenas o jogador ativa
        {
            if (item1 != null) item1.SetActive(true);
            if (item2 != null) item2.SetActive(true);
            
        }
    }
}
