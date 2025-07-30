using UnityEngine;

public class HideSpot : MonoBehaviour
{
    public GameObject sightBlockerObject;  // Objeto que ser� ativado/desativado como SightBlocker
    private EnemyAi enemyAi;

    private void Start()
    {
        enemyAi = FindObjectOfType<EnemyAi>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Se o inimigo N�O estiver vendo o player ao entrar, ativa o esconderijo
            if (!enemyAi.CanSeePlayer())
            {
                sightBlockerObject.layer = LayerMask.NameToLayer("SightBlockers");
            }
            else
            {
                sightBlockerObject.layer = LayerMask.NameToLayer("Default"); // n�o bloqueia vis�o
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Saiu do esconderijo -> volta ao layer normal
            sightBlockerObject.layer = LayerMask.NameToLayer("Default");
        }
    }
}
