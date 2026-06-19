using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public void Buy(GameItem item, GameObject button)
    {
        var price = item.itemPrice;
        var totalPrice = price - (price * discount * 0.01f);

        if(totalPrice <= pItems.money)
        {
            pItems.AddItems(item);
            pItems.money -= totalPrice;

            //Check if the item can only be bought once per appearance
            if (item.singleBuy)
            {
                /*button.GetComponent<Button>().interactable = false;
                button.transform.Find("Icon").GetComponent<Image>().sprite = item.boughtIcon;*/
                button.GetComponent<StoreBtn>().CloseDescription();
                Destroy(button);

                allItems.Remove(item);
            }
        }
    }
    public void ListItem(GameItem item)
    {
        GameObject obj = Instantiate(storeItems, itemContent);

        var itemSprite = obj.transform.GetChild(0).GetComponent<Image>();
        var itemName = obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        var itemAmount = obj.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        var itemPrice = obj.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        

        //Setting the UI interface
        itemSprite.sprite = item.icon;
        itemName.text = item.itemName;
        itemAmount.text = item.amount.ToString();;
        itemPrice.text = $"${item.itemPrice.ToString()}";

        obj.GetComponent<StoreBtn>().ChangeButton(item);
    }
}