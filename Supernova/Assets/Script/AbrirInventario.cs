using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    [Header("Objeto do inventário a ser ativado/desativado")]
    public GameObject inventoryUI;

    private bool isInventoryOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        inventoryUI.SetActive(isInventoryOpen);

        if (isInventoryOpen)
        {
            Time.timeScale = 0f; // Pausa o jogo
        }
        else
        {
            Time.timeScale = 1f; // Retoma o jogo
        }
    }
}
