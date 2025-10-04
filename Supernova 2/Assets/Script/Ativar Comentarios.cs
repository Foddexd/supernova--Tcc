using UnityEngine;

public class Dialogos : MonoBehaviour
{
    public GameObject item1;
 
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Garante que apenas o jogador ativa
        {
            if (item1 != null) item1.SetActive(true);
            

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Garante que apenas o jogador ativa
        {
            if (item1 != null) item1.SetActive(false);
          

        }

    }
}
