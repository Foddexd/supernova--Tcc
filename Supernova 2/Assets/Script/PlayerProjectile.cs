using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float lifetime = 5f;
    public int damage = 1;
    public string targetTag = "Enemy"; // Não usado diretamente, mas mantido para compatibilidade

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ignora colisão com o player
        if (other.CompareTag("Player"))
        {
            return; // Não destrói nem faz nada
        }

        // Check para ExplosiveBarrel (prioridade alta, pois explode)
        if (other.CompareTag("ExplosiveBarrel"))
        {
            ExplosiveBarrel barrel = other.GetComponent<ExplosiveBarrel>();
            if (barrel != null)
            {
                barrel.TakeDamage(damage);
            }
            Destroy(gameObject); // Destrói após processar
            return; // Sai do método
        }

        // Check para Enemy (inclui boss, assumindo tag "Enemy")
        if (other.CompareTag("Enemy"))
        {
            EnemyAi enemy = other.GetComponent<EnemyAi>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Dano na vida do inimigo/boss
            }

            // Integra o stun para boss aqui (se tiver BossStun)
            BossStun stun = other.GetComponent<BossStun>();
            if (stun != null)
            {
                stun.LevarTiro(); // Conta o tiro para stun
                Debug.Log("Tiro contado no boss! (via Enemy tag)"); // Log para debug
            }

            Destroy(gameObject); // Destrói após processar
            return; // Sai do método
        }

        // Check específico para Boss (caso tenha tag separada "Boss" e não "Enemy")
        if (other.CompareTag("Boss"))
        {
            // Se tem EnemyAi, aplica dano na vida também
            EnemyAi enemy = other.GetComponent<EnemyAi>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Sempre conta para stun
            BossStun stun = other.GetComponent<BossStun>();
            if (stun != null)
            {
                stun.LevarTiro();
                Debug.Log("Tiro contado no boss! (via Boss tag)"); // Log para debug
            }

            Destroy(gameObject);
            return;
        }

        // Para qualquer outra colisão (ex: parede, chão), destrói a bala
        Destroy(gameObject);
    }
}