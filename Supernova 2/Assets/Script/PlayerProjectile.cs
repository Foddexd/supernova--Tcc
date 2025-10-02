using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float lifetime = 5f;
    public int damage = 1;
    public string targetTag = "Enemy"; // N�o usado diretamente, mas mantido para compatibilidade

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ignora colis�o com o player
        if (other.CompareTag("Player"))
        {
            return; // N�o destr�i nem faz nada
        }

        // Check para ExplosiveBarrel (prioridade alta, pois explode)
        if (other.CompareTag("ExplosiveBarrel"))
        {
            ExplosiveBarrel barrel = other.GetComponent<ExplosiveBarrel>();
            if (barrel != null)
            {
                barrel.TakeDamage(damage);
            }
            Destroy(gameObject); // Destr�i ap�s processar
            return; // Sai do m�todo
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

            Destroy(gameObject); // Destr�i ap�s processar
            return; // Sai do m�todo
        }

        // Check espec�fico para Boss (caso tenha tag separada "Boss" e n�o "Enemy")
        if (other.CompareTag("Boss"))
        {
            // Se tem EnemyAi, aplica dano na vida tamb�m
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

        // Para qualquer outra colis�o (ex: parede, ch�o), destr�i a bala
        Destroy(gameObject);
    }
}