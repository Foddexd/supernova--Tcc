using UnityEngine;
using UnityEngine.UI;

public class OrdemInventario : MonoBehaviour
{
    public GameObject[] inventorySlots; // GameObjects dos slots (em ordem)
    public Sprite[] itemIcons;          // ícones de cada item correspondente

    
    public void AddItem(int itemId)
    {
        foreach (GameObject slot in inventorySlots)
        {
            Image image = slot.GetComponent<Image>();

            if (!slot.activeSelf)
            {
                slot.SetActive(true);           // Ativa o slot
                image.sprite = itemIcons[itemId]; // Define o ícone do item
                return;
            }
        }

        Debug.Log("Inventário cheio!");
    }
}
