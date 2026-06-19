using UnityEngine;

[CreateAssetMenu(menuName = "Item/Game Item")]
public class GameItem : ScriptableObject
{
    [Header("Identification")]
    public string itemName;
    public int id;
    public enum ItemType
    {
        glyph,
        upgrade,
        general,
        consumable,
    }
    public ItemType itemType;
    [TextArea(4,4)]
    public string description;

    [Header("Store")]
    public float itemPrice;
    public Sprite icon;
    public Sprite boughtIcon;

    [Header("Other")]
    public int ammount;
}