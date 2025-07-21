using UnityEngine;
using UnityEngine.UI;

public class OrdemInventario : MonoBehaviour
{
    public GameObject[] inventorySlots; // Arraste aqui os GameObjects dos slots (em ordem)
    public Sprite[] itemIcons;          // Arraste os �cones de cada item correspondente

    // M�todo para adicionar um item ao invent�rio
    public void AddItem(int itemId)
    {
        foreach (GameObject slot in inventorySlots)
        {
            Image image = slot.GetComponent<Image>();

            if (!slot.activeSelf)
            {
                slot.SetActive(true);           // Ativa o slot
                image.sprite = itemIcons[itemId]; // Define o �cone do item
                return;
            }
        }

        Debug.Log("Invent�rio cheio!");
    }
}
