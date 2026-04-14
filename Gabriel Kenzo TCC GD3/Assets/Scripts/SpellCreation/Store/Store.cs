using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [Header("Items")]
    public List<GameItem> allItems, possibleItems, itemsToSell;
    public int numOfItems;

    [Header("UI")]
    public Transform itemContent;
    public GameObject storeItems;

    [Header("Buying")]
    public float discount; //Value in percentage
    public PlayerItems pItems;
    public List<GameObject> btns;
    [SerializeField] private bool removeFromShop = false, singleBuy = false;

    private void Start()
    {
        ChooseItems();
    }
    
    public void ChooseItems()
    {
        itemsToSell.Clear();
        possibleItems = allItems;
        for(int i = 0; i < numOfItems; i++)
        {
            int itemToAdd = Random.Range(0, allItems.Count);

            itemsToSell.Add(allItems[itemToAdd]);
            ListItem(allItems[itemToAdd]);
            allItems.RemoveAt(itemToAdd);
        }
    }

    public void Buy(int itemNum)
    {
        if(itemsToSell[itemNum].itemPrice - (itemsToSell[itemNum].itemPrice * discount * 0.01f) <= pItems.money)
        {
            pItems.gameItems.Add(itemsToSell[itemNum]);
            pItems.money -= itemsToSell[itemNum].itemPrice - (itemsToSell[itemNum].itemPrice * discount * 0.01f);

            //Check if the item can only be bought once per appearance
            if (singleBuy)
            {
                btns[itemNum].gameObject.GetComponent<Button>().interactable = false;
                btns[itemNum].transform.Find("Icon").GetComponent<Image>().sprite = itemsToSell[itemNum].boughtIcon;

                //Check if the item can only be bought once
                if(removeFromShop)
                {
                    allItems.Remove(itemsToSell[itemNum]);

                    //Check if the bought item is a glyph
                    if(itemsToSell[itemNum].itemType == GameItem.ItemType.glyph) pItems.CheckGlyphs();
                }
            }
        }
    }
    public void ListItem(GameItem item)
    {
        GameObject obj = Instantiate(storeItems, itemContent);
        var itemName = obj.transform.Find("Name").GetComponent<Text>();
        var itemPrice = obj.transform.Find("Price").GetComponent<Text>();
        var itemSprite = obj.transform.Find("Icon").GetComponent<Sprite>();

        //Setting the UI interface
        itemName.text = item.itemName;
        itemPrice.text = item.itemPrice.ToString();
        itemSprite = item.storeIcon;
        btns.Add(obj);
    }
}