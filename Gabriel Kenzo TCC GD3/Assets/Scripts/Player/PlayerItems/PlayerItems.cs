using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public float money = 0;
    public List<GameObject> items;
    public List<GameItem> gameItems;
    public List<GameItem> upgrades;
    public List<GameItem> glyphs;

    public static PlayerItems instance;

    public void AddItems(GameObject item)
    {
        items.Add(item);
    }
    public void RemoveItems(GameObject item)
    {
        items.Remove(item);
    }
    public void RemoveGameItems(GameItem gameItem)
    {
        gameItems.Remove(gameItem);
    }
    public void CheckGlyphs()
    {
        for(int i = 0; i < gameItems.Count; i++)
        {
            if(gameItems[i].itemType == GameItem.ItemType.glyph)
            {
                glyphs.Add(gameItems[i]);
                ItemsHolder.unlockedGlyphs.Add(gameItems[i]);
                gameItems.RemoveAt(i);
                i--;
            }
        }
    }
    public void CheckUpgrades()
    {
        for(int i = 0; i < gameItems.Count; i++)
        {
            if(gameItems[i].itemType == GameItem.ItemType.upgrade)
            {
                glyphs.Add(gameItems[i]);
                ItemsHolder.upgrades.Add(gameItems[i]);
                gameItems.RemoveAt(i);
                i--;
            }
        }
    }
    public void CheckConsumables()
    {
        for(int i = 0; i < gameItems.Count; i++)
        {
            if(gameItems[i].itemType == GameItem.ItemType.consumable)
            {
                glyphs.Add(gameItems[i]);
                ItemsHolder.consumables.Add(gameItems[i]);
                gameItems.RemoveAt(i);
                i--;
            }
        }
    }

    public void EndStage()
    {
        foreach (GameObject obj in items){
            ItemsHolder.items.Add(obj);
        }
        ItemsHolder.money += money;
    }
}