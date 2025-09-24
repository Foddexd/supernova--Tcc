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

        // Instanciar efeito de explosão (opcional)
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius, bossLayer);
        foreach (Collider hit in hitColliders)
        {
            EnemyAi boss = hit.GetComponent<EnemyAi>();
            if (boss != null)
            {
                boss.TakeBarrelDamage(damageToBoss);
            }
        }

     
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}