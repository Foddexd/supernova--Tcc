using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventarioJogador : MonoBehaviour
{
    public float pesoMaximo = 50f;
    public List<ItemNoInventario> itens = new List<ItemNoInventario>();

    public float PesoAtual
    {
        get
        {
            float total = 0f;
            foreach (var item in itens)
                total += item.PesoTotal;
            return total;
        }
    }

    public bool PodeAdicionar(Item item, int quantidade)
    {
        return PesoAtual + (item.peso * quantidade) <= pesoMaximo;
    }

    public bool AdicionarItem(Item item, int quantidade)
    {
        if (!PodeAdicionar(item, quantidade)) return false;

        var existente = itens.Find(i => i.itemBase == item);
        if (existente != null)
        {
            existente.quantidade += quantidade;
        }
        else
        {
            itens.Add(new ItemNoInventario { itemBase = item, quantidade = quantidade });
        }

        return true;
    }

    public void RemoverItem(Item item, int quantidade)
    {
        var existente = itens.Find(i => i.itemBase == item);
        if (existente != null)
        {
            existente.quantidade -= quantidade;
            if (existente.quantidade <= 0)
                itens.Remove(existente);
        }
    }
}
