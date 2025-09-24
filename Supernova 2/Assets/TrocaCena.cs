using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaCena : MonoBehaviour
{
    
    public string nomeDaCena;

   
    public void CarregarCena()
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}
