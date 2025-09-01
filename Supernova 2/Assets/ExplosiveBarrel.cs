using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public float explosionRadius = 5f;
    public int damageToBoss = 1;
    public LayerMask bossLayer;
    public GameObject explosionEffect;

    private bool exploded = false;

    public void TakeDamage(int damage)
    {
        if (exploded) return;

        Explode();
    }

    private void Explode()
    {
        exploded = true;

        // Instanciar efeito de explos�o (opcional)
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Detectar o boss na �rea da explos�o
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius, bossLayer);
        foreach (Collider hit in hitColliders)
        {
            EnemyAi boss = hit.GetComponent<EnemyAi>();
            if (boss != null)
            {
                boss.TakeBarrelDamage(damageToBoss);
            }
        }

        // Destruir o barril ap�s a explos�o
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        // Visualizar o raio da explos�o na cena
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}