using UnityEngine;

public class AbrirPuzzle : MonoBehaviour
{
    public GameObject Puzzle;
    public GameObject TextoInteração;
    public KeyCode toggleKey = KeyCode.E;

    public bool PlayerNoTrigger = false;
    public bool PuzzleAberto = false;

    private bool isOpen = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerNoTrigger = true;
            TextoInteração.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerNoTrigger = false;
            TextoInteração.SetActive(false);
            
        }
    }

    void Update()
    {
        if (PlayerNoTrigger && Input.GetKeyDown(KeyCode.E))
        {
            EstadoPuzzle();
        }
    }

    // Método público para ser chamado pelo botão mobile
    public void EstadoPuzzle()
    {
        PuzzleAberto = !PuzzleAberto;
        Puzzle.SetActive(PuzzleAberto);
        Time.timeScale = PuzzleAberto ? 0 : 1;
    }
}