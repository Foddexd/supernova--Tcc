using UnityEngine;
using TMPro;

public class TemporarioInventario : MonoBehaviour
{
    public GameObject objetoParaVerificar;
    public TextMeshProUGUI textoTMP;

    void Update()
    {
        if (objetoParaVerificar == null || textoTMP == null)
            return;

        if (objetoParaVerificar.activeSelf)
        {
            textoTMP.text = " Espaço usado: 5/50";
        }
        else
        {
            textoTMP.text = " Espaço usado: 0/50";
        }
    }
}
