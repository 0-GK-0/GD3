using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class SpellItem : ScriptableObject
{
    public int id;
    public string itemname;
    public int value;
    public int addedMana;
    public float addedCooldown;
    public Sprite icon;
}
