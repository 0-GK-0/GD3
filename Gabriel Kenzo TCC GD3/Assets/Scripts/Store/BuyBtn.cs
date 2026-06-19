using System.Collections.Generic;
using UnityEngine;

public class BuyBtn : MonoBehaviour
{
    [Header("Button Setup")]
    [SerializeField] private PlayerItems pItems;
    [SerializeField] private Store store;
    GameItem itemToBuy;
    GameObject shopButton;


    public void SetButton(GameItem item, GameObject button)
    {
        itemToBuy = item;
        shopButton = button;
    }
    public void Buy()
    {
        store.Buy(itemToBuy, shopButton);
    }
}
