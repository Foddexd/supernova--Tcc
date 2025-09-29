using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CadeadoNumerico : MonoBehaviour
{
    public int[] numeros = new int[3]; // Os números atuais do cadeado
    public int[] numerosMaximos = new int[3] { 9, 9, 9 }; // Máximo para cada dígito (ex: 0-9)
    public int[] numerosMinimos = new int[3] { 0, 0, 0 }; // Mínimo para cada dígito

    public int[] sequenciaCorreta = new int[3] { 1, 2, 3 }; // Sequência correta para destravar

    public TMP_Text[] textosNumeros; // Referência aos textos TextMeshPro que mostram os números na UI
    public TMP_Text mensagem; // Texto TextMeshPro para mostrar mensagem de sucesso

    private bool desbloqueado = false;

    public AbrirPuzzle abrirPuzzleScript;

    public GameObject ColliderAbrirMinigame;
    public GameObject TextoInteragir;

    private void Start()
    {
        AtualizarTexto();
        mensagem.text = "";
    }

  
    public void AumentarNumero(int indice)
    {
        numeros[indice]++;
        if (numeros[indice] > numerosMaximos[indice])
            numeros[indice] = numerosMinimos[indice];
        AtualizarTexto();
        VerificarSequencia();
    }

   
    public void DiminuirNumero(int indice)
    {
        numeros[indice]--;
        if (numeros[indice] < numerosMinimos[indice])
            numeros[indice] = numerosMaximos[indice];
        AtualizarTexto();
        VerificarSequencia();
    }

   
    void AtualizarTexto()
    {
        for (int i = 0; i < numeros.Length; i++)
        {
            textosNumeros[i].text = numeros[i].ToString();
        }
    }

   
    void VerificarSequencia()
    {
        for (int i = 0; i < numeros.Length; i++)
        {
            if (numeros[i] != sequenciaCorreta[i])
            {
                mensagem.text = "";
                return;
            }
        }
        mensagem.gameObject.SetActive(true);
        mensagem.text = "Cadeado destravado!";
        desbloqueado = true;
        StartCoroutine(FecharMinigame());
        
    }
    IEnumerator FecharMinigame()
    {
        abrirPuzzleScript.EstadoPuzzle();
        yield return new WaitForSecondsRealtime(2f);
        mensagem.gameObject.SetActive(false);
        ColliderAbrirMinigame.gameObject.SetActive(false);
        TextoInteragir.gameObject.SetActive(false);
        
    }
}