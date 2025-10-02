using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BossStun : MonoBehaviour
{
    [Header("Configura��es do Stun")]
    public int tirosParaStun = 5; // Quantidade de tiros necess�rios para ativar o stun
    public float duracaoStun = 3f; // Dura��o do stun em segundos
    public string triggerAnimacaoStun = "Stun"; // Nome do trigger da anima��o de stun no Animator
    public string triggerAnimacaoRecuperacao = "Recovery"; // Nome do trigger da anima��o de recupera��o no Animator

    [Header("Refer�ncias")]
    public NavMeshAgent agent; // Refer�ncia ao NavMeshAgent (pode ser atribu�do no Inspector ou pego automaticamente)
    public EnemyAi enemyAi; // Refer�ncia ao script EnemyAi para pausar a IA durante o stun

    private int tirosAtuais = 0; // Contador de tiros atuais
    private bool estaStunado = false; // Flag para verificar se est� stunado
    private float timerStun = 0f; // Timer para contar a dura��o do stun
    private Animator animator; // Refer�ncia ao Animator para tocar anima��es

    private void Awake()
    {
        // Pega as refer�ncias automaticamente se n�o forem atribu�das no Inspector
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
    /// M�todo p�blico para ser chamado quando o boss leva um tiro (ex: do script de bala do player).
    /// Chame isso em vez de (ou al�m de) TakeDamage se quiser contar tiros separadamente da vida.
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
    /// Ativa o stun: reseta contador, toca anima��o, para o agente e inicia timer.
    /// </summary>
    private void AtivarStun()
    {
        estaStunado = true;
        tirosAtuais = 0; // Reseta o contador para permitir stun novamente ap�s a recupera��o
        timerStun = duracaoStun;

        // Toca a anima��o de stun (se houver Animator)
        if (animator != null)
        {
            animator.SetTrigger(triggerAnimacaoStun);
        }

        // Para o agente de navega��o
        agent.isStopped = true;

        // Opcional: Pausa a l�gica da IA no EnemyAi (adicione uma flag p�blica no EnemyAi se necess�rio)
        // Por exemplo, no Update do EnemyAi: if (GetComponent<BossStun>().estaStunado) return;

        Debug.Log("Boss stunado! Parado por " + duracaoStun + " segundos.");
    }

    /// <summary>
    /// Recupera do stun: toca anima��o de recupera��o e retoma o movimento.
    /// </summary>
    private void Recuperar()
    {
        estaStunado = false;

        // Toca a anima��o de recupera��o (se houver Animator)
        if (animator != null)
        {
            animator.SetTrigger(triggerAnimacaoRecuperacao);
        }

        // Retoma o movimento do agente
        agent.isStopped = false;

        // Retoma a IA (se voc� adicionar a verifica��o no EnemyAi, ela voltar� automaticamente)

        Debug.Log("Boss recuperado! Voltando ao normal.");
    }

    // Propriedade p�blica para que o EnemyAi possa verificar se est� stunado
    public bool EstaStunado
    {
        get { return estaStunado; }
    }
}