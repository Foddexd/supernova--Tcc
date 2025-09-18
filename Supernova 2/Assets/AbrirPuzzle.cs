using UnityEngine;

public class AbrirPuzzle : MonoBehaviour
{
    public GameObject Puzzle;
    public GameObject TextoIntera��o;
    public KeyCode toggleKey = KeyCode.E;

    public bool PlayerNoTrigger = false;
    public bool PuzzleAberto = false;

    private bool isOpen = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerNoTrigger = true;
            TextoIntera��o.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerNoTrigger = false;
            TextoIntera��o.SetActive(false);
            
        }
    }

    void Update()
    {
        if (PlayerNoTrigger && Input.GetKeyDown(KeyCode.E))
        {
            EstadoPuzzle();
        }
    }

    // M�todo p�blico para ser chamado pelo bot�o mobile
    public void EstadoPuzzle()
    {
        PuzzleAberto = !PuzzleAberto;
        Puzzle.SetActive(PuzzleAberto);
        Time.timeScale = PuzzleAberto ? 0 : 1;
    }
}