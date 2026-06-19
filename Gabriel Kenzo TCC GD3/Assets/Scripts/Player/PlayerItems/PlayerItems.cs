using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItems : MonoBehaviour
{
    [Header("Data")]
    public float money = 0;
    public List<GameItem> gameItems;

    [Header("Containers")]
    [SerializeField] private GameObject generalContainer;
    [SerializeField] private GameObject consumablesContainer;
    [SerializeField] private GameObject glyphsContainer;
    [SerializeField] private GameObject upgradesContainer;
    [SerializeField] private GameObject elseContainer;

    [Header("References")]
    [SerializeField] private GameObject itemBtn;


    public void AddAll()
    {
        foreach (GameItem item in gameItems)
        {
            AddItems(item);
        }
    }
    public void AddItems(GameItem item)
    {
        Debug.Log(item);
        if (item.itemType == GameItem.ItemType.general) AddGameItem(item, ItemsHolder.gameItems);
        else if (item.itemType == GameItem.ItemType.consumable) AddGameItem(item, ItemsHolder.consumables);
        else if (item.itemType == GameItem.ItemType.upgrade) AddGameItem(item, ItemsHolder.upgrades);
        else if (item.itemType == GameItem.ItemType.glyph) AddGameItem(item, ItemsHolder.unlockedGlyphs);
        else AddGameItem(item, ItemsHolder.items);
    }
    public void AddGameItem(GameItem item, List<InventoryItem> gameItemList)
    {
        Debug.Log($"{item}, {gameItemList}");
        int index = gameItemList.FindIndex(x => x.itemData.id == item.id);
        if (index >= 0)
        {   
            gameItemList[index].amount += item.amount;
            gameItemList[index].amountText.text = gameItemList[index].amount.ToString();
            return;
        }
        
        InventoryItem newItem = new InventoryItem(item, item.amount);
        gameItemList.Add(newItem);
        if (item.itemType == GameItem.ItemType.general)
        {
            PlaceItem(newItem, generalContainer.transform);
        }
        else if (item.itemType == GameItem.ItemType.consumable)
        {
            PlaceItem(newItem, consumablesContainer.transform);
        }
        else if (item.itemType == GameItem.ItemType.glyph)
        {
            PlaceItem(newItem, glyphsContainer.transform);
        }
        else if (item.itemType == GameItem.ItemType.upgrade)
        {
            PlaceItem(newItem, upgradesContainer.transform);
        }
        else
        {
            PlaceItem(newItem, elseContainer.transform);
        }
    }

    //Place in UI
    public void PlaceItem(InventoryItem item, Transform container)
    {
        GameObject obj = Instantiate(itemBtn, container.transform);
        obj.transform.GetChild(0).transform.GetComponent<Image>().sprite = item.itemData.icon;
        obj.transform.GetChild(1).transform.GetComponent<TextMeshProUGUI>().text = item.itemData.itemName;
        obj.transform.GetChild(2).transform.GetComponent<TextMeshProUGUI>().text = item.amount.ToString();

        item.amountText = obj.transform.GetChild(2).transform.GetComponent<TextMeshProUGUI>();
    }

    public void PlaceAll()
    {
        foreach (InventoryItem item in ItemsHolder.gameItems)
        {
            PlaceItem(item, generalContainer.transform);
        }
        foreach (InventoryItem item in ItemsHolder.consumables)
        {
            PlaceItem(item, consumablesContainer.transform);
        }
        foreach (InventoryItem item in ItemsHolder.unlockedGlyphs)
        {
            PlaceItem(item, glyphsContainer.transform);
        }
        foreach (InventoryItem item in ItemsHolder.upgrades)
        {
            PlaceItem(item, upgradesContainer.transform);
        }
        foreach (InventoryItem item in ItemsHolder.items)
        {
            PlaceItem(item, elseContainer.transform);
        }
    }
    public void RemoveItems(GameItem item, int amount)
    {
        if (item.itemType == GameItem.ItemType.general)
        {
            int index = ItemsHolder.gameItems.FindIndex(x => x.itemData.id == item.id);
            if (index >= 0)
            {
                if(ItemsHolder.gameItems[index].amount >= amount)
                {
                    ItemsHolder.gameItems[index].amount -= amount;
                    if(ItemsHolder.gameItems[index].amount == 0)
                    {
                        ItemsHolder.gameItems.RemoveAt(index);
                    }
                }
                else
                {
                    Debug.Log("Unable to Remove");
                }
            }
        }
        else if (item.itemType == GameItem.ItemType.consumable)
        {
            int index = ItemsHolder.consumables.FindIndex(x => x.itemData.id == item.id);
            if (index >= 0)
            {
                if(ItemsHolder.consumables[index].amount >= amount)
                {
                    ItemsHolder.consumables[index].amount -= amount;
                    if(ItemsHolder.consumables[index].amount == 0)
                    {
                        ItemsHolder.consumables.RemoveAt(index);
                    }
                }
                else
                {
                    Debug.Log("Unable to Remove");
                }
            }
        }
        else if (item.itemType == GameItem.ItemType.upgrade)
        {
            int index = ItemsHolder.upgrades.FindIndex(x => x.itemData.id == item.id);
            if (index >= 0)
            {
                if(ItemsHolder.upgrades[index].amount >= amount)
                {
                    ItemsHolder.upgrades[index].amount -= amount;
                    if(ItemsHolder.upgrades[index].amount == 0)
                    {
                        ItemsHolder.upgrades.RemoveAt(index);
                    }
                }
                else
                {
                    Debug.Log("Unable to Remove");
                }
            }
        }
        /*else if (item.itemType == GameItem.ItemType.glyph)
        {
            if (ItemsHolder.unlockedGlyphs.Contains(item))
            {
                if(ItemsHolder.unlockedGlyphs[ItemsHolder.unlockedGlyphs.IndexOf(item)].amount >= amount)
                {
                    ItemsHolder.unlockedGlyphs[ItemsHolder.unlockedGlyphs.IndexOf(item)].amount -= amount;
                }
                else
                {
                    Debug.Log("Unable to Remove");
                }
            }
        }*/
        else
        {
            int index = ItemsHolder.items.FindIndex(x => x.itemData.id == item.id);
            if (index >= 0)
            {
                if(ItemsHolder.items[index].amount >= amount)
                {
                    ItemsHolder.items[index].amount -= amount;
                    if(ItemsHolder.items[index].amount == 0)
                    {
                        ItemsHolder.items.RemoveAt(index);
                    }
                }
                else
                {
                    Debug.Log("Unable to Remove");
                }
            }
        }
    }

    /*public void EndStage()
    {
        foreach (GameObject obj in items){
            ItemsHolder.items.Add(obj);
        }
        ItemsHolder.money += money;
    }*/
}