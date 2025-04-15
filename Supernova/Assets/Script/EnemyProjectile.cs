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
            // Mesmo que n�o seja o jogador, destr�i o projetil (opcional)
            Destroy(gameObject);
        }
    }
}
