using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BossStun : MonoBehaviour
{
    [Header("Configurações do Stun")]
    public int tirosParaStun = 5; // Quantidade de tiros necessários para ativar o stun
    public float duracaoStun = 3f; // Duração do stun em segundos
    public string triggerAnimacaoStun = "Stun"; // Nome do trigger da animação de stun no Animator
    public string triggerAnimacaoRecuperacao = "Recovery"; // Nome do trigger da animação de recuperação no Animator

    [Header("Referências")]
    public NavMeshAgent agent; // Referência ao NavMeshAgent (pode ser atribuído no Inspector ou pego automaticamente)
    public EnemyAi enemyAi; // Referência ao script EnemyAi para pausar a IA durante o stun

    private int tirosAtuais = 0; // Contador de tiros atuais
    private bool estaStunado = false; // Flag para verificar se está stunado
    private float timerStun = 0f; // Timer para contar a duração do stun
    private Animator animator; // Referência ao Animator para tocar animações

    private void Awake()
    {
        // Pega as referências automaticamente se não forem atribuídas no Inspector
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        if (enemyAi == null)
            enemyAi = GetComponent<EnemyAi>();

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
       
        // Durante o stun, conta o tempo e para o movimento
        if (estaStunado)
        {
            timerStun -= Time.deltaTime;
            agent.isStopped = true; // Garante que o agente pare

            if (timerStun <= 0f)
            {
                Recuperar();
            }
        }
    }

    /// <summary>
    /// Método público para ser chamado quando o boss leva um tiro (ex: do script de bala do player).
    /// Chame isso em vez de (ou além de) TakeDamage se quiser contar tiros separadamente da vida.
    /// </summary>
    public void LevarTiro()
    {
        if (estaStunado) return; // Ignora tiros durante o stun

        tirosAtuais++;
        Debug.Log($"Boss levou um tiro! Tiros atuais: {tirosAtuais}/{tirosParaStun}");

        if (tirosAtuais >= tirosParaStun)
        {
            AtivarStun();
        }
    }

    /// <summary>
    /// Ativa o stun: reseta contador, toca animação, para o agente e inicia timer.
    /// </summary>
    private void AtivarStun()
    {
        estaStunado = true;
        tirosAtuais = 0; // Reseta o contador para permitir stun novamente após a recuperação
        timerStun = duracaoStun;

        // Toca a animação de stun (se houver Animator)
        if (animator != null)
        {
            animator.SetTrigger(triggerAnimacaoStun);
        }

        // Para o agente de navegação
        agent.isStopped = true;

        // Opcional: Pausa a lógica da IA no EnemyAi (adicione uma flag pública no EnemyAi se necessário)
        // Por exemplo, no Update do EnemyAi: if (GetComponent<BossStun>().estaStunado) return;

        Debug.Log("Boss stunado! Parado por " + duracaoStun + " segundos.");
    }

    /// <summary>
    /// Recupera do stun: toca animação de recuperação e retoma o movimento.
    /// </summary>
    private void Recuperar()
    {
        estaStunado = false;

        // Toca a animação de recuperação (se houver Animator)
        if (animator != null)
        {
            animator.SetTrigger(triggerAnimacaoRecuperacao);
        }

        // Retoma o movimento do agente
        agent.isStopped = false;

        // Retoma a IA (se você adicionar a verificação no EnemyAi, ela voltará automaticamente)

        Debug.Log("Boss recuperado! Voltando ao normal.");
    }

    // Propriedade pública para que o EnemyAi possa verificar se está stunado
    public bool EstaStunado
    {
        get { return estaStunado; }
    }
}