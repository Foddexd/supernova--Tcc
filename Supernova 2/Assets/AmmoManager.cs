using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public int cartuchos = 0;

    public void AdicionarCartucho(int quantidade = 1)
    {
        cartuchos += quantidade;
        Debug.Log($"AmmoManager: AdicionarCartucho -> {cartuchos}");
    }

    public bool ConsumirCartucho()
    {
        if (cartuchos > 0)
        {
            cartuchos--;
            Debug.Log($"AmmoManager: ConsumirCartucho -> {cartuchos}");
            return true;
        }
        return false;
    }

    public int GetCartuchos()
    {
        return cartuchos;
    }
}
