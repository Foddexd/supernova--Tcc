using UnityEngine;

[CreateAssetMenu(fileName = "NovoItem", menuName = "Inventario/Item")]
public class Item : ScriptableObject
{
    public string nome;
    public Sprite icone;
    public float peso;
}
