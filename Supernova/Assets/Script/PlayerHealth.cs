using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public GameObject player;

    [Header("Objetos ativados com dano")]
    public GameObject objetoCom60DeVida;
    public GameObject objetoCom30DeVida;

    private void Start()
    {
        currentHealth = maxHealth;
        AtualizarIndicadoresDeVida();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Tomou dano! Vida atual: " + currentHealth);

        AtualizarIndicadoresDeVida();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void AtualizarIndicadoresDeVida()
    {
        if (objetoCom60DeVida != null)
            objetoCom60DeVida.SetActive(currentHealth <= 60 && currentHealth > 30 );

        if (objetoCom30DeVida != null)
            objetoCom30DeVida.SetActive(currentHealth <= 30);
    }

    void Die()
    {
        Debug.Log("O jogador morreu!");
        Destroy(player.gameObject);
    }
}
