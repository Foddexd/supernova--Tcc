using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float lifetime = 5f;
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyAi enemy = other.GetComponent<EnemyAi>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
        else if (!other.CompareTag("Player")) // não destrói se colidir com o jogador
        {
            Destroy(gameObject);
        }
    }
}
