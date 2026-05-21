using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

public class PlayerItems : MonoBehaviour
{
    public float money = 0;
    public List<GameObject> items;
    public List<GameItem> gameItems;
    public List<GameItem> glyphs;

    public static PlayerItems instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
                gameItems.RemoveAt(i);
                i--;
            }
        }
    }
}