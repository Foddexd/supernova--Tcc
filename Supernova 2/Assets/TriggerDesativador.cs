using UnityEngine;

public class TriggerDesativador : MonoBehaviour
{
    public GameObject item1;
    public GameObject item2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Garante que apenas o jogador ativa
        {
            item1.SetActive(false);
            item2.SetActive(false);
        }
    }
}
