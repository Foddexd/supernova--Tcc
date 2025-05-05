using System;
using static UnityEditor.Progress;

[Serializable]
public class ItemNoInventario
{
    public Item itemBase;
    public int quantidade;

    public float PesoTotal => itemBase.peso * quantidade;
}
