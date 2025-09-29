using UnityEngine;
using TMPro;

[System.Serializable]
public class InventoryItem
{
    public string itemName;   // Nome do item, para comparar
    public int spaceTaken;    // Quanto espa�o esse item ocupa
    public bool isActive;     // Se o item est� no invent�rio
    public GameObject linkedObject; // O objeto da UI que vai ser ativado/desativado
}

public class InventoryManager : MonoBehaviour
{
    public int maxInventorySize = 50;
    public InventoryItem[] items; 
    public TextMeshProUGUI spaceText;

    private void Start()
    {
        UpdateActiveItemsFromScene();
    }

    
    public void UpdateInventoryUI()
    {
        int usedSpace = 0;

        // Soma o espa�o ocupado pelos itens ativos
        foreach (InventoryItem item in items)
        {
            if (item.isActive)
                usedSpace += item.spaceTaken;
        }

        // Calcula o espa�o restante e atualiza a UI
        int remainingSpace = maxInventorySize - usedSpace;
        spaceText.text = $"Espa�o: {remainingSpace} / {maxInventorySize}";
    }

   
    public void UpdateActiveItemsFromScene()
    {
        foreach (InventoryItem item in items)
        {
            if (item.linkedObject != null)
            {
                // Verifica se o objeto est� ativo na UI
                if (item.linkedObject.activeInHierarchy)
                {
                    item.isActive = true;  // Marca o item como ativo
                }
                else
                {
                    item.isActive = false; // Marca o item como inativo
                }
            }
        }

      
        UpdateInventoryUI();
    }

   
    public void ToggleItem(int index)
    {
        if (index >= 0 && index < items.Length)
        {
            // Alterna o estado ativo/inativo do item
            items[index].isActive = !items[index].isActive;
            UpdateInventoryUI(); 
        }
    }
}
