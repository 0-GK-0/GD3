using UnityEngine;

[CreateAssetMenu(fileName = "Glyph", menuName = "Item/Create New Glyph")]
public class SpellItem : ScriptableObject
{
    [field: Header("Spell")]
    [field: SerializeField] public int id {get; private set;}
    [field: SerializeField] public string itemname {get; private set;}
    [field: SerializeField] public int value {get; private set;}

    [field: Header("Spell Cost")]
    [field: SerializeField] public int addedMana {get; private set;}
    [field: SerializeField] public float addedCooldown {get; private set;}

    [field: Header("UI")]
    [field: SerializeField] public Sprite icon {get; private set;}
}
