using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public float money = 0;
    public List<GameItem> gameItems;

    public static PlayerItems instance;

    public void AddItems(GameItem item)
    {
        gameItems.Add(item);
    }
    public void RemoveItems(GameItem item)
    {
        gameItems.Remove(item);
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
    }
    public void RemoveGameItems(GameItem gameItem)
    {
        gameItems.Remove(gameItem);
    }

    public void CheckAll()
    {
        CheckGlyphs();
        CheckUpgrades();
        CheckConsumables();

    }

    public void CheckGlyphs()
    {
        for(int i = 0; i < gameItems.Count; i++)
        {
            if(gameItems[i].itemType == GameItem.ItemType.glyph)
            {
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
                ItemsHolder.consumables.Add(gameItems[i]);
                gameItems.RemoveAt(i);
                i--;
            }
        }
    }
    public void AddToGeneral()
    {
        foreach (GameItem obj in gameItems)
        {
            ItemsHolder.items.Add(obj);
            gameItems.Remove(obj);
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