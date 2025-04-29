using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPausa;
    private bool jogoPausado = false;

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
