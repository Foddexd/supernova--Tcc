using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotInventarioUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public TooltipItem tooltip;

    public Image icone;

    public void Configurar(Item novoItem, TooltipItem refTooltip)
    {
        item = novoItem;
        tooltip = refTooltip;
        icone.sprite = novoItem.icone;
        icone.enabled = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
            tooltip.MostrarTooltip(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.EsconderTooltip();
    }
}
