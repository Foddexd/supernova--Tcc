using UnityEngine;

public class HideSpot : MonoBehaviour
{
    public GameObject sightBlockerObject;  // Objeto que será ativado/desativado como SightBlocker
    private EnemyAi enemyAi;

    private void Start()
    {
        enemyAi = FindObjectOfType<EnemyAi>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Se o inimigo NÃO estiver vendo o player ao entrar, ativa o esconderijo
            if (!enemyAi.CanSeePlayer())
            {
                sightBlockerObject.layer = LayerMask.NameToLayer("SightBlockers");
            }
            else
            {
                sightBlockerObject.layer = LayerMask.NameToLayer("Default"); // não bloqueia visão
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
