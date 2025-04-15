using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colidiu com: " + other.name);

        if (other.CompareTag("Player"))
        {
            PlayerHealth vida = other.GetComponent<PlayerHealth>();

            if (vida != null)
            {
                Debug.Log("Acertou o jogador! Aplicando dano.");
                vida.TakeDamage(10);
            }

            Destroy(gameObject);
        }
        else
        {
            // Mesmo que não seja o jogador, destrói o projetil (opcional)
            Destroy(gameObject);
        }
    }
}
