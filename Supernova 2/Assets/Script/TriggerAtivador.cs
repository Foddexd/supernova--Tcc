using UnityEngine;

public class TriggerActivator : MonoBehaviour
{
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Garante que apenas o jogador ativa
        {
            if (item1 != null) item1.SetActive(true);
            if (item2 != null) item2.SetActive(true);
            if (item3 != null) item3.SetActive(false);
            if (item4 != null) item4.SetActive(false);
            if (item5 != null) item5.SetActive(true);
          

        }
    }
}
