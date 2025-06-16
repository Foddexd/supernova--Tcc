using UnityEngine;
using UnityEngine.UI;

public class TooltipItem : MonoBehaviour
{
    public GameObject tooltipObject;
    public Text tooltipText;

    public void MostrarTooltip(Item item)
    {
        tooltipObject.SetActive(true);
        tooltipText.text = $"{item.nome}\nPeso: {item.peso}";
    }

    public void EsconderTooltip()
    {
        tooltipObject.SetActive(false);
    }
}
