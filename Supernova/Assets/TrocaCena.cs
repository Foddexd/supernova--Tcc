using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCena : MonoBehaviour
{
    // Nome da cena que será carregada
    public string nomeDaCena;

    // Método para trocar de cena
    public void CarregarCena()
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}
