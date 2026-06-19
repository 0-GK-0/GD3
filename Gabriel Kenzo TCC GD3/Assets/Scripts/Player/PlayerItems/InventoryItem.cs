using TMPro;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public GameItem itemData;
    public int amount;

    [System.NonSerialized] public TextMeshProUGUI amountText;

    public InventoryItem(GameItem item, int amount)
    {
        this.itemData = item;
        this.amount = amount;
    }
}
