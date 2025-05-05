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
    public InventoryItem[] items; // Preencha no Inspetor
    public TextMeshProUGUI spaceText;

    private void Start()
    {
        UpdateActiveItemsFromScene(); // Inicializa com os objetos da cena
    }

    // Atualiza o valor visual do invent�rio
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

    // Atualiza os itens ativos com base nos GameObjects da UI arrastados
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

        // Atualiza a UI com o status atual
        UpdateInventoryUI();
    }

    // M�todo para ativar um item espec�fico (exemplo)
    public void ToggleItem(int index)
    {
        if (index >= 0 && index < items.Length)
        {
            // Alterna o estado ativo/inativo do item
            items[index].isActive = !items[index].isActive;
            UpdateInventoryUI(); // Atualiza a UI
        }
    }
}
