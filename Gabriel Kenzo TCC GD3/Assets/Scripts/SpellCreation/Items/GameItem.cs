using UnityEngine;

[CreateAssetMenu(menuName = "Item/Game Item")]
public class GameItem : ScriptableObject
{
    [Header("Data")]
    public string itemName;
    public enum ItemType
    {
        glyph,
        upgrade,
    }
    public ItemType itemType;

    [Header("Store")]
    public float itemPrice;
    public Sprite storeIcon;
    public Sprite boughtIcon;
}