using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPausa;
    private bool jogoPausado = false;
    public GameObject MenuCreditos;
    public GameObject MenuOpções;
    public GameObject MenuControles;
    public GameObject MenuPrincipal;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (jogoPausado)
                RetomarJogo();
            else
                PausarJogo();
        }
    }

    public void FecharCreditos()
    {
        Time.timeScale = 1f;
        MenuCreditos.SetActive(false);
        MenuPrincipal.SetActive(true);
    }
    public void FecharOpções()
    {
        Time.timeScale = 1f;
        MenuOpções.SetActive(false);
        MenuPrincipal.SetActive(true);
    }
    public void FecharControles()
    {
        Time.timeScale = 1f;
        MenuControles.SetActive(false);
        MenuPrincipal.SetActive(true);
    }
    public void AbrirOpções()
    {
        Time.timeScale = 1f;
        MenuPrincipal.SetActive(false);
        MenuOpções.SetActive(true);
    }
    public void AbrirCreditos()
    {
        Time.timeScale = 1f;
        MenuPrincipal.SetActive(false);
        MenuCreditos.SetActive(true);
    }
    public void AbrirControles()
    {
        Time.timeScale = 1f;
        MenuPrincipal.SetActive(false);
        MenuControles.SetActive(true);
    }
    public void PausarJogo()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        jogoPausado = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RetomarJogo()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        jogoPausado = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1f; // Garante que o tempo volte ao normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SairDoJogo()
    {
        Time.timeScale = 1f; // Opcional, em caso de estar pausado
        Application.Quit();
        Debug.Log("Jogo encerrado"); // Apenas aparece no editor
    }
}
