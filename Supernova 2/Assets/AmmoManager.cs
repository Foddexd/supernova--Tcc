using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public int cartuchos = 0;

    public void AdicionarCartucho()
    {
        cartuchos++;
    }

    public bool ConsumirCartucho()
    {
        if (cartuchos > 0)
        {
            cartuchos--;
            return true;
        }
        return false;
    }

    public int GetCartuchos()
    {
        return cartuchos;
    }
}
