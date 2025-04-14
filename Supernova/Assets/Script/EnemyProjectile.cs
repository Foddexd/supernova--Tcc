using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float lifeTime = 5f;
    public int damage = 1;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Supondo que o jogador tenha um script com TakeDamage
            other.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
