using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCena : MonoBehaviour
{
    // Nome da cena que ser� carregada
    public string nomeDaCena;

    // M�todo para trocar de cena
    public void CarregarCena()
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}
