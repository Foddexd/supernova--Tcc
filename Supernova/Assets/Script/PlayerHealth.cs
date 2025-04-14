using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    [Header("Objetos ativados com dano")]
    public GameObject objetoCom2DeVida;
    public GameObject objetoCom1DeVida;

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
        if (objetoCom2DeVida != null)
            objetoCom2DeVida.SetActive(currentHealth == 2);

        if (objetoCom1DeVida != null)
            objetoCom1DeVida.SetActive(currentHealth == 1);
    }

    void Die()
    {
        Debug.Log("O jogador morreu!");
        // gameObject.SetActive(false);
    }
}
