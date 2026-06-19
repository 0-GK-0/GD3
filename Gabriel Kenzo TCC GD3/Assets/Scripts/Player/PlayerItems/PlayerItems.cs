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
    public static PlayerItems instance;
    [SerializeField] private GameObject itemBtn;

    public void AddItems(GameItem item)
    {
        if (item.itemType == GameItem.ItemType.general) AddGameItem(item, ItemsHolder.gameItems);
        else if (item.itemType == GameItem.ItemType.consumable) AddGameItem(item, ItemsHolder.consumables);
        else if (item.itemType == GameItem.ItemType.upgrade) AddGameItem(item, ItemsHolder.upgrades);
        else if (item.itemType == GameItem.ItemType.glyph) AddGameItem(item, ItemsHolder.unlockedGlyphs);
        else AddGameItem(item, ItemsHolder.items);
    }
    public void RemoveItems(GameItem item, int ammount)
    {
        if (item.itemType == GameItem.ItemType.general)
        {
            if (ItemsHolder.gameItems.Contains(item))
            {
                if(ItemsHolder.gameItems[ItemsHolder.gameItems.IndexOf(item)].ammount >= ammount)
                {
                    ItemsHolder.gameItems[ItemsHolder.gameItems.IndexOf(item)].ammount -= ammount;
                }
                else
                {
                    Debug.Log("Unable to Remove");
                }
            }
        }
        else if (item.itemType == GameItem.ItemType.consumable)
        {
            if (ItemsHolder.consumables.Contains(item))
            {
                if(ItemsHolder.consumables[ItemsHolder.consumables.IndexOf(item)].ammount >= ammount)
                {
                    ItemsHolder.consumables[ItemsHolder.consumables.IndexOf(item)].ammount -= ammount;
                }
                else
                {
                    Debug.Log("Unable to Remove");
                }
            }
        }
        else if (item.itemType == GameItem.ItemType.upgrade)
        {
            if (ItemsHolder.upgrades.Contains(item))
            {
                if(ItemsHolder.upgrades[ItemsHolder.upgrades.IndexOf(item)].ammount >= ammount)
                {
                    ItemsHolder.upgrades[ItemsHolder.upgrades.IndexOf(item)].ammount -= ammount;
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
                if(ItemsHolder.unlockedGlyphs[ItemsHolder.unlockedGlyphs.IndexOf(item)].ammount >= ammount)
                {
                    ItemsHolder.unlockedGlyphs[ItemsHolder.unlockedGlyphs.IndexOf(item)].ammount -= ammount;
                }
                else
                {
                    Debug.Log("Unable to Remove");
                }
            }
        }*/
        else
        {
            if (ItemsHolder.items.Contains(item))
            {
                if(ItemsHolder.items[ItemsHolder.items.IndexOf(item)].ammount >= ammount)
                {
                    ItemsHolder.items[ItemsHolder.items.IndexOf(item)].ammount -= ammount;
                }
                else
                {
                    Debug.Log("Unable to Remove");
                }
            }
        }
    }

    public void AddGameItem(GameItem item, List<GameItem> gameItemList)
    {
        for (int i = 0; i < gameItemList.Count; i++)
        {
            if (gameItemList[i].id == item.id)
            {
                gameItemList[i].ammount += item.ammount;
                return;
            }
        }
        gameItemList.Add(item);
        if (item.itemType == GameItem.ItemType.general)
        {
            PlaceGeneral(item);
        }
        else if (item.itemType == GameItem.ItemType.consumable)
        {
            PlaceConsumable(item);
        }
        else if (item.itemType == GameItem.ItemType.glyph)
        {
            PlaceGlyph(item);
        }
        else if (item.itemType == GameItem.ItemType.upgrade)
        {
            PlaceUpgrade(item);
        }
        else
        {
            PlaceElse(item);
        }
    }

    //Place in UI
    public void PlaceGeneral(GameItem item)
    {
        GameObject obj = Instantiate(itemBtn, generalContainer.transform);
        obj.transform.GetChild(0).transform.GetComponent<Image>().sprite = item.icon;
        obj.transform.GetChild(1).transform.GetComponent<TextMeshProUGUI>().text = item.itemName;
        obj.transform.GetChild(2).transform.GetComponent<TextMeshProUGUI>().text = item.ammount.ToString();
    }
    public void PlaceConsumable(GameItem item)
    {
        GameObject obj = Instantiate(itemBtn, consumablesContainer.transform);
        obj.transform.GetChild(0).transform.GetComponent<Image>().sprite = item.icon;
        obj.transform.GetChild(1).transform.GetComponent<TextMeshProUGUI>().text = item.itemName;
        obj.transform.GetChild(2).transform.GetComponent<TextMeshProUGUI>().text = item.ammount.ToString();
    }
    public void PlaceGlyph(GameItem item)
    {
        GameObject obj = Instantiate(itemBtn, glyphsContainer.transform);
        obj.transform.GetChild(0).transform.GetComponent<Image>().sprite = item.icon;
        obj.transform.GetChild(1).transform.GetComponent<TextMeshProUGUI>().text = item.itemName;
        obj.transform.GetChild(2).transform.GetComponent<TextMeshProUGUI>().text = item.ammount.ToString();
    }
    public void PlaceUpgrade(GameItem item)
    {
        GameObject obj = Instantiate(itemBtn, upgradesContainer.transform);
        obj.transform.GetChild(0).transform.GetComponent<Image>().sprite = item.icon;
        obj.transform.GetChild(1).transform.GetComponent<TextMeshProUGUI>().text = item.itemName;
        obj.transform.GetChild(2).transform.GetComponent<TextMeshProUGUI>().text = item.ammount.ToString();
    }
    public void PlaceElse(GameItem item)
    {
        GameObject obj = Instantiate(itemBtn, elseContainer.transform);
        obj.transform.GetChild(0).transform.GetComponent<Image>().sprite = item.icon;
        obj.transform.GetChild(1).transform.GetComponent<TextMeshProUGUI>().text = item.itemName;
        obj.transform.GetChild(2).transform.GetComponent<TextMeshProUGUI>().text = item.ammount.ToString();
    }

    public void PlaceAll()
    {
        foreach (GameItem item in ItemsHolder.gameItems)
        {
            PlaceGeneral(item);
        }
        foreach (GameItem item in ItemsHolder.consumables)
        {
            PlaceConsumable(item);
        }
        foreach (GameItem item in ItemsHolder.unlockedGlyphs)
        {
            PlaceGlyph(item);
        }
        foreach (GameItem item in ItemsHolder.upgrades)
        {
            PlaceUpgrade(item);
        }
        foreach (GameItem item in ItemsHolder.items)
        {
            PlaceElse(item);
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